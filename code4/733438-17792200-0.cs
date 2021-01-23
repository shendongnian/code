    public void delegate OnError(object sender, string message);
    public event OnError OnErrorEvent; 
    
    ...
 
               client.DownloadStringCompleted += (senders, ex) =>
                {
                    if (ex.Error == null)
                    {
                        //Process the result...
                        return ex.Result;
                    }
                    else
                    {
                       if(OnErrorEvent != null)
                       OnErrorEvent(this, "An error occurred. The details of the error: " + ex.Error;);
                    }
                };
