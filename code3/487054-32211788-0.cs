    [HttpGet]
        [Route("api/DownloadPdfFile/{id}")]
        public HttpResponseMessage DownloadPdfFile(long id)
        {
            HttpResponseMessage result = null;
            try
            {
                SQL.File file= db.Files.Where(b => b.ID == id).SingleOrDefault();
                if (file == null)
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {
                    // sendo file to client
                    byte[] bytes = Convert.FromBase64String(file.pdfBase64);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new ByteArrayContent(bytes);
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = file.name +".pdf";
                }
                return result;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Gone);
            }
        }
