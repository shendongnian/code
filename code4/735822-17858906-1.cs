    public void ProcessRequest(HttpContext context)
      {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            var email = context.Request.Params["user_email"];
            var fileData = context.Request.Files["file"];
            try
            {
                 var result =  UploadImageToServer(email, fileData);
                  context.Response.Write(result);
            }
            catch (Exception ex)
            {
                  context.Response.Write("error while uploading file to the server, please try again.");
            }
      }
