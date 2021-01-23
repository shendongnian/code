    using System.Web;
    public class loadimage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string url = "https://............10000.JPG";
            byte[] imageData;
            using (WebClient client = new WebClient())
            {
                imageData = client.DownloadData(url);
            }
            context.Response.OutputStream.Write(imageData, 0, imageData.Length);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
