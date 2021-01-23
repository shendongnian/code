     public void ProcessRequest(HttpContext context)
        {
          // your first code
          // ...
           if (!File.Exists(path))
            {
                ctx.Response.Status = "Image not found";
                ctx.Response.StatusCode = 404;
            }
            else
            {
                // load here the image 
                ....
                // and send it to browser
                ctx.Response.OutputStream.Write(imageData, 0, imageData.Length);
            }
        }
