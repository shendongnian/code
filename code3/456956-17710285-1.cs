    public Task<IEnumerable<string>> Post()
    {
        if (Request.Content.IsMimeMultipartContent())
        {
            string fullPath = HttpContext.Current.Server.MapPath("~/uploads");
            MyMultipartFormDataStreamProvider streamProvider = new MyMultipartFormDataStreamProvider(fullPath);
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                var fileInfo = streamProvider.FileData.Select(i =>
                {
                    var info = new FileInfo(i.LocalFileName);
                    return "File uploaded as " + info.FullName + " (" + info.Length + ")";
                });
                return fileInfo;
            });
            return task;
        }
        else
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
        }
    }
