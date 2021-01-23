    public void ProcessRequest (HttpContext context) 
    {
        byte[] data = File.ReadAllBytes(@"Your Path");
        context.Response.ContentType = "application/pdf";
        context.Response.OutputStream.Write(data, 0, data.Length);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}`
