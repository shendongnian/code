       public void ProcessRequest(HttpContext context)
        {
          // this is a header that you can get when you read the image
          context.Response.ContentType = "image/jpeg";
          // the size of the image
          context.Response.AddHeader("Content-Length", imageData.Length.ToString());
          // cache the image - 24h example
          context.Response.Cache.SetExpires(DateTime.Now.AddHours(24));
          context.Response.Cache.SetMaxAge(new TimeSpan(24, 0, 0));
          // render direct
          context.Response.BufferOutput = false;
    
          // load here the image as you do
          ....
    
          // and send it to browser
          context.Response.OutputStream.Write(imageData, 0, imageData.Length);
        }
