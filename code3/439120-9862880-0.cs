    // 1x1 transparent GIF
    private readonly byte[] GifData = {
        0x47, 0x49, 0x46, 0x38, 0x39, 0x61,
        0x01, 0x00, 0x01, 0x00, 0x80, 0xff,
        0x00, 0xff, 0xff, 0xff, 0x00, 0x00,
        0x00, 0x2c, 0x00, 0x00, 0x00, 0x00,
        0x01, 0x00, 0x01, 0x00, 0x00, 0x02,
        0x02, 0x44, 0x01, 0x00, 0x3b
    };
    
    public void ProcessRequest (HttpContext context) 
    {
         if (UrlManipulation.IsRoutedValueInt(context.Request["ID"]))
         {
            int PostID = Convert.ToInt32(context.Request["ID"]);
            PostManipulation.AddPostView(PostID);
         }
        // set the cache    
        context.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(10));
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.Cache.SetValidUntilExpires(true);
    
        // send the image
        context.Response.ContentType = "image/gif";
        context.Response.Buffer = false;
        context.Response.OutputStream.Write(GifData, 0, GifData.Length);
    }
