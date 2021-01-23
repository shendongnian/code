    public static void ListenerCallback(IAsyncResult result)
    {
        HttpListener listener = (HttpListener) result.AsyncState;
        // Use EndGetContext to complete the asynchronous operation.
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        // Get response object.
        HttpListenerResponse response = context.Response;
        // Construct a response. 
        string responseString = "<HTML><BODY> It Works!</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Write to response stream.
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer,0,buffer.Length);
        // Close the output stream.
        output.Close();
    }
