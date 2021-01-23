    public string UploadFile()
    {
        if (Request.Content.IsMimeMultipartContent())
        {
            //Save file
            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Files"));
            
			Request.Content.ReadAsMultipart(provider); // don't know if this is really valid.
				
            return provider.BodyPartFileNames.First().Value;
        }
        else
        {
            return "Invalid.";
        }
    }
