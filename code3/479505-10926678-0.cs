    void EnsureCourseImageCached(HttpContext context)
    {
       string courseKey = context.Request.QueryString["ck"];
       string objKey = context.Request.QueryString["file"];
    
       var image = context.Cache[objKey] as Bitmap;
    
       if (image != null) return image;
    
       using (var response = Gets3Response(objKey, courseKey, context))
       { 
          image = new Bitmap(reponse.ResponseStream);
          context.Cache.Insert(objKey, image, null, DateTime.UtcNow.AddMinutes(20),  
       }
    
       return image;
    }
    
    void WriteCourseImage(HttpContext context)
    {
        var image = EnsureCourseImageCached(context);
    
        image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
    }
