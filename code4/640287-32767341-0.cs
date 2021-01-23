        [System.Web.Http.AcceptVerbs("Post")]
        [System.Web.Http.HttpPost]
        public Task<HttpResponseMessage> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string fileSaveLocation = @"c:\SaveYourFile\Here\XXX";
            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(fileSaveLocation);
            Task<HttpResponseMessage> task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        //Do Work Here
                    }
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            );
            return task;
        }
