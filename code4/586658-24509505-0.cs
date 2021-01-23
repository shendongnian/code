    [Route("{bulkRequestId:int:min(1)}/Permissions")]
        [ResponseType(typeof(IEnumerable<Pair>))]
        public async Task<IHttpActionResult> PutCertificatesAsync(int bulkRequestId)
        {
            if (Request.Content.IsMimeMultipartContent("form-data"))
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/uploads");
                var streamProvider = new MyStreamProvider(uploadPath);
                await Request.Content.ReadAsMultipartAsync(streamProvider);
                List<Pair> messages = new List<Pair>();
                foreach (var file in streamProvider.FileData)
                {
                    FileInfo fi = new FileInfo(file.LocalFileName);
                    messages.Add(new Pair(fi.FullName, Guid.NewGuid()));
                }
                //if (_biz.SetCertificates(bulkRequestId, fileNames))
                //{
                return Ok(messages);
                //}
                //return NotFound();
            }
            return BadRequest();
        }
    }
    
    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath) : base(uploadPath)
        {
        }
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = Guid.NewGuid().ToString()
                + Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
            return fileName;
        }
    }
