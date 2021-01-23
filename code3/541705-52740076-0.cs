    you can use from that In block Try-Catch.
     [HttpGet]
        public HttpResponseMessage DownloadVideo(Guid id, string title)
        {
            try
            {
              //Your Code at the end return result
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
