    // this is the start call from the handler
    public void ProcessRequest(HttpContext context)
    {
        // imageData is the byte we have read from previous
        context.Response.OutputStream.Write(imageData, 0, imageData.Length);
    }
