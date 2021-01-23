HttpListener listener = new HttpListener();
//add your prefixes here
listener.Start();
AsyncCallback processRequest = delegate(IAsyncResult result)
{
    //set the listener to listen for next request
    listener.BeginGetContext(processRequest, listener);
    HttpListenerContext context = listener.EndGetContext(result);
    //Your code to handle the request here
}
listener.BeginGetContext(processRequest, listener);
