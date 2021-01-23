    public static void GetData()
    {    
    	//this will be called on UIThread of Android
    	com.unity3d.player.UnityPlayer.currentActivity.runOnUiThread(new Runnable(){
    		public void run(){
    			cTaskResult taskResult = new cTaskResult();
    		    taskResult = BackgroundTask.DoAsyncTask(ServerAddressValue, ServerPortValue, vServerName, vSensorNumber);
    		    vTaskResult = taskResult.ResultData;
                    com.unity3d.player.UnityPlayer.currentActivity.SendMessage("YourGameObjectName", "YourMethodName", taskResult.DataIsReady);
    		    //return taskResult.DataIsReady;	
    		}
    	});
        
    }
