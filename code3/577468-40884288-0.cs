    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    public class btnGetData : MonoBehaviour {
     void Start()
     {
         gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
     }
     IEnumerator WaitForWWW(WWW www)
     {
         yield return www;
        
         
         string txt = "";
         if (string.IsNullOrEmpty(www.error))
             txt = www.text;  //text of success
         else
             txt = www.error;  //error
         GameObject.Find("Txtdemo").GetComponent<Text>().text =  "++++++\n\n" + txt;
     }
     void TaskOnClick()
     {
         try
         {
             GameObject.Find("Txtdemo").GetComponent<Text>().text = "starting..";   
             string ourPostData = "{\"plan\":\"TESTA02\"";
             Dictionary<string,string> headers = new Dictionary<string, string>();
             headers.Add("Content-Type", "application/json");
             //byte[] b = System.Text.Encoding.UTF8.GetBytes();
             byte[] pData = System.Text.Encoding.ASCII.GetBytes(ourPostData.ToCharArray());
             ///POST by IIS hosting...
             WWW api = new WWW("http://192.168.1.120/si_aoi/api/total", pData, headers);
             ///GET by IIS hosting...
             ///WWW api = new WWW("http://192.168.1.120/si_aoi/api/total?dynamix={\"plan\":\"TESTA02\"");
             StartCoroutine(WaitForWWW(api));
         }
         catch (UnityException ex) { Debug.Log(ex.Message); }
     } 
    }
