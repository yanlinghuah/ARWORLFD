using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CharactorControl : MonoBehaviour
{
    public GameObject model;
    private List<ARRaycastHit> hits;
    private ARRaycastManager manager;
    private GameObject mModel;
    // Start is called before the first frame update
    void Start()
    {
        hits = new List<ARRaycastHit>();
        manager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0){
            return;
        }
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began &&
         manager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon)){
            Pose pose = hits[0].pose;
            Instantiate(model, pose.position, pose.rotation);
         }
    }
}
