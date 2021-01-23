    public class Handler : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            HttpPostedFile fileToUpload = context.Request.Files["Filedata"];
            string pathToSave = HttpContext.Current.Server.MapPath("~/Files/")
                                + fileToUpload.FileName;
            fileToUpload.SaveAs(pathToSave);
            //Process file
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
