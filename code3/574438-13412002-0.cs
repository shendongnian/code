    using System.Text;
    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {
         //System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
         string PostbackData = Encoding.UTF8.GetString(context.Request.BinaryRead(context.Request.TotalBytes));
    }
