    public Task<string> UploadFile()
    {
        if (Request.Content.IsMimeMultipartContent())
        {
            //Save file
            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Files"));
            Task<IEnumerable<HttpContent>> task = Request.Content.ReadAsMultipartAsync(provider);
            return task.ContinueWith<string>(contents =>
            {
                return provider.BodyPartFileNames.First().Value;
            }, TaskScheduler.FromCurrentSynchronizationContext()); 
        }
        else
        {
            // For returning non-async stuff, use a TaskCompletionSource to avoid thread switches
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            tcs.SetResult("Invalid.");
            return tcs.Task;
        }
    }
