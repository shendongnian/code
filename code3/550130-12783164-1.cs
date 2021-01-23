    public void ProcessRequest (HttpContext context) 
    {
        ....
        context.Response.AppendHeader("Content-Type", "video/mp4");`
        context.Response.AppendHeader("Accept-Ranges", "bytes");
        byte[] fileContents = GetYourBytesFromWhereEver();
        context.Response.OutputStream.Write(fileContents, 0, fileContents.Length);
        context.Response.Flush();
        .....
    }
