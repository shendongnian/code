    public void SendVoice(byte[] audio)
    {
    	//Keep a list of connected clients in a dictionary called subscribers
        //lock your subscribers list so that it's not modified when you're in the middle of sending the stream              
            lock (subscribers)
            {
    	    //send the received voice stream to each client
                foreach (var _subscriber in subscribers)
                {
                    if (OperationContext.Current.GetCallbackChannel<IVoiceChatCallback>() == subscriber.Key)
                    {
    			//if the person who sent the video is the current subscriber then don't send the video to THAT subscriber
                                continue;
                    }
                    try
                    {
    		         //Send the received stream to the client asynchronously
                                _subscriber.Key.BeginOnVoiceSendCallback(audio, onNotifyCompletedVoiceSend, _subscriber.Key);
                     }
                     catch (Exception)
                     {
                            	//fault handling
                     }
    	        }
    	    }
    }
