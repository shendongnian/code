    static void Context(IAsyncResult result)
    {
        HttpListener listener = (HttpListener)result.AsyncState;
       try
       {
            //If we are not listening this line throws a ObjectDisposedException.
            HttpListenerContext context = listener.EndGetContext(result);
    
            context.Response.Close();
            listener.BeginGetContext(Context, listener);
       }
       catch (ObjectDisposedException)
       {
           //Intentionally not doing anything with the exception.
       }
    }
