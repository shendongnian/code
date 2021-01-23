    static void Context(IAsyncResult result)
    {
        HttpListener listener = (HttpListener)result.AsyncState;
        //If not listening return immediately as this method is called one last time after Close()
        if (!listener.IsListening)
            return;
        //If we are not listening this line throws a ObjectDisposedException.
        HttpListenerContext context = listener.EndGetContext(result);
        context.Response.Close();
        listener.BeginGetContext(Context, listener);
    }
