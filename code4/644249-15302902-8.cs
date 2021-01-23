    public class ReadTheCameraImage : IHttpHandler 
    {
         public void ProcessRequest (HttpContext context) 
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Buffer = false;
            // read the ImageData from what ever source you have
            context.Response.OutputStream.Write(ImageData, 0, ImageData.Length);        
        }
    
        public bool IsReusable 
        {
            get {
                return false;
            }
        }
    }
