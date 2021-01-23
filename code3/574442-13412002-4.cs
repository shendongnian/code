    using System.Text;
    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {
         //System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
         string postbackData = context.Request.ContentEncoding.GetString(context.Request.BinaryRead(context.Request.TotalBytes));
    }
