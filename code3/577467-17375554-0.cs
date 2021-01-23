        public class RequestConnectionManager : Manager<RequestConnectionManager>
        {
        
        public int maxSubmissionAttempts = 3;
        
        public Coroutine post() {
            		WWWForm playForm = new WWWForm();
                    playForm.AddField("id", myJson.id);
            		playForm.AddField("name", myJson.name);
                    
            		Post playPost = new Post("http://index.php", playForm, maxSubmissionAttempts, this);
                    return StartCoroutine(PostWorker(playPost));
            	}
        
        private IEnumerator PostWorker(Post playPost)
            {
        		yield return null;
        		yield return playPost.Submit();
        		
        		Debug.Log(playPost.Response);
        		if (playPost.Error != null)
        		{
        			MessageBoxManager.Instance.Show("Error: " + playPost.Error, "Error", MessageBoxManager.OKCancelOptionLabels, MessageOptions.Ok);
        		}
        		else
        		{
        			try
        			{
                        //do whatever you want in here
        				//Hashtable response = JsonReader.Deserialize<Hashtable>(playPost.Response);
        				//Debug.Log("UNITY LOG..." + response);
        				
        			}
                    catch (JsonDeserializationException jsExc)
                    {
                        Debug.Log(jsExc.Message);
                        Debug.Log(playPost.Response);
                    }
                    catch (Exception exc)
                    {
                        Debug.Log(exc.Message);
                        Debug.Log(playPost.Response);
                    }
        			
        		}
        	}
        
        }
        
    //As for the Manager class...
    
    using UnityEngine;
    using System.Collections;
    
    
    // I wonder what the constraint where TManager : Singleton<TManager> would produce...
    public class Manager<TManager> : SingletonW<TManager> where TManager : MonoBehaviour
    {
     
        override protected void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(gameObject);
        }
        
    }
