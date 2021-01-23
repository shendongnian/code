    public void ProcessRequest(HttpContext context)
        {
          {
                // load here the image 
                ....
                // and send it to browser
                ctx.Response.OutputStream.Write(imageData, 0, imageData.Length);
           }
        }
