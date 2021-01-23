    using UnityEngine;
    using System.Collections;
    public class OverlapButton : MonoBehaviour {
        public string id_;
        void OnGUI(){
                if(GUI.Button(new Rect(0,0,50,50),"Touch")){
                        Debug.Log("I'm object " + id_);
                }
        }
    }
