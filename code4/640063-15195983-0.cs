    public class UploadController : ApiController
    {
        public Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HostingEnvironment.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            // Read the form data
            return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
