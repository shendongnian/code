    public class UploadController : ApiController
    {
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var appData = HostingEnvironment.MapPath("~/App_Data");
            var folder = Path.Combine(appData, Guid.NewGuid().ToString());
            Directory.CreateDirectory(folder);
            var provider = new MultipartFormDataStreamProvider(folder);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            if (result.FileData.Count < 1)
            {
                // no files were uploaded at all
                // TODO: here you could return an error message to the client if you want
            }
            // at this stage all files that were uploaded by the user will be
            // stored inside the folder we specified without us needing to do
            // any additional steps
            // we can now read some additional FormData
            string caption = result.FormData["caption"];
            // TODO: update your database with the other data that was posted
            return Request.CreateResponse(HttpStatusCode.OK, "thanks for uploading");
        }
    }
