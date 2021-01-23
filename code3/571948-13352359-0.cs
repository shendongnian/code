    static void Context(IAsyncResult result)
    {
        HttpListener listener = (HttpListener)result.AsyncState;
        //If not listening return immediately as this method is called on last time after Close()
        if (!listener.IsListening)
            return;
        HttpListenerContext context = listener.EndGetContext(result);
        context.Response.Close();
        listener.BeginGetContext(Context, listener);
    }
