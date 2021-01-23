        public class DownloadController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string fileName)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            string fileLocation = HttpContext.Current.Server.MapPath("~/Downloads" + fileName);
            if (!File.Exists(fileLocation))
            {
                throw new HttpResponseException(HttpStatusCode.OK);
            }
            Stream fileStream = File.Open(fileLocation, FileMode.Open);
            result.Content = new StreamContent(fileStream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            return result;
        }
    }
