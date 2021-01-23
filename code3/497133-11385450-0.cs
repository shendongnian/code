    private void OnRequestReceive(IAsyncResult result) 
    { 
        HttpListener listener = (HttpListener)result.AsyncState; 
        HttpListenerContext context = listener.EndGetContext(result); 
        HttpListenerResponse response = context.Response; 
        byte[] buff = {1,2,3}; 
 
        response.Close(buff, true); 
        // ---> start listening for another request
        listener.BeginGetContext(new AsyncCallback(OnRequestReceive), listener); 
    }  
