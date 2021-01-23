        [HttpPost]
        public string MassExportDocuments(MassExportDocumentsInput input)
        {
            // Save query for file download use
            var guid = Guid.NewGuid();
            HttpContext.Current.Cache.Insert(guid.ToString(), input, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            return guid.ToString();
        }
       [HttpGet]
        public async Task<HttpResponseMessage> MassExportDocuments([FromUri] Guid guid)
        {
            //Get params from cache, generate and return
            var model = (MassExportDocumentsInput)HttpContext.Current.Cache[guid.ToString()];
              ..... // Document generation
            // to determine when file is downloaded
            HttpContext.Current
                       .Response
                       .SetCookie(new HttpCookie("fileDownload", "true") { Path = "/" });
            return FileResult(memoryStream, "documents.zip", "application/zip");
        }
