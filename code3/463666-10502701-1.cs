    public string UploadFile()
    {
        if (Request.Content.IsMimeMultipartContent())
        {
            //Save file
            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Files"));
            Task<IEnumerable<HttpContent>> task = Request.Content.ReadAsMultipartAsync(provider);
            string filename = "Not set";
            var finalTask = task.ContinueWith(o =>
				{
					//File name
					filename = provider.BodyPartFileNames.First().Value;
				}, TaskScheduler.FromCurrentSynchronizationContext()); 
			task.Start();
			
			finalTask.Wait();
				
            return filename;
        }
        else
        {
            return "Invalid.";
        }
    }
