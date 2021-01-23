    using System;
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class WWWRequestor : MonoBehaviour 
    {
    
    	Dictionary<WWW, object> mRequestData = new Dictionary<WWW, object>();
    	public delegate void WWWRequestFinished(string pSuccess, string pData);
    
    	void Start() { }
    
    	public WWW GET(string url, WWWRequestFinished pDelegate)
    	{
    		WWW aWww = new WWW(url);
    		mRequestData[aWww] = pDelegate;
    
    		StartCoroutine(WaitForRequest(aWww));
    		return aWww;
    	}
    
    	public WWW POST(string url, Dictionary<string, string> post, WWWRequestFinished pDelegate)
    	{
    		WWWForm aForm = new WWWForm();
    		foreach (KeyValuePair<String, String> post_arg in post)
    		{
    			aForm.AddField(post_arg.Key, post_arg.Value);
    		}
    		WWW aWww = new WWW(url, aForm);
    
    		mRequestData[aWww] = pDelegate;
    		StartCoroutine(WaitForRequest(aWww));
    		return aWww;
    	}
    
    	private IEnumerator WaitForRequest(WWW pWww)
    	{
    		yield return pWww;
    
    		// check for errors
    		string aSuccess = "success";
    		if (pWww.error != null)
    		{
    			aSuccess = pWww.error;
    		}
    
    		WWWRequestFinished aDelegate = (WWWRequestFinished) mRequestData[pWww];
    		aDelegate(aSuccess, pWww.text);
    		mRequestData.Remove(pWww);
    	}
    
    }
