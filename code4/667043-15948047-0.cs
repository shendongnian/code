    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    
    public class SoundPlayer : MonoBehaviour {
    	
    	string absolutePath = "./"; // relative path to where the app is running
    	
    	AudioSource src;
    	List<AudioClip> clips = new List<AudioClip>();
    	int soundIndex = 0;
    	
      //compatible file extensions
    	string[] fileTypes = {"ogg","wav"};
    	
    	FileInfo[] files;
    	
    	void Start () {
        //being able to test in unity
    		if(Application.isEditor)	absolutePath = "Assets/";
        
        if(src == null) src = gameObject.AddComponent<AudioSource>();
        
    		reloadSounds();
    	}
    	
    	void reloadSounds() {
    		DirectoryInfo info = new DirectoryInfo(absolutePath);
    		files = info.GetFiles();
    		
        //check if the file is valid and load it
    		foreach(FileInfo f in files){
    			if(validFileType(f.FullName)){
    				//Debug.Log("Start loading "+f.FullName);
    				StartCoroutine(loadFile(f.FullName));
    			}
    		}
    		
      }
    	
    	bool validFileType(string filename){
    		foreach(string ext in fileTypes){
    			if(filename.IndexOf(ext) > -1) return true;
    		}
    		return false;
    	}
    	
    	IEnumerator loadFile(string path){
    		WWW www = new WWW("file://"+path);
    		
    		AudioClip myAudioClip = www.audioClip;
    		while (!myAudioClip.isReadyToPlay)
    		yield return www;
    		
    		AudioClip clip = www.GetAudioClip(false);
    		string[] parts = path.Split('\\');
    		clip.name = parts[parts.Length - 1];
    		clips.Add(clip);
    	}
    	
    }
