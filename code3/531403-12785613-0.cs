        public HttpResponseMessage Get()
        {
            string path = @"PATH_TO_XLS";
            MemoryStream responseStream = new MemoryStream();
            using (Stream fileStream = File.Open(path, FileMode.Open))
            {
                fileStream.CopyTo(responseStream);
                fileStream.Close();
            }
            responseStream.Position = 0;
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StreamContent(responseStream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "PY75.xls" };
            return response;
        }
