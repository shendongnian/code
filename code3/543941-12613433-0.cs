    public class SignatureHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int recordid = Convert.ToInt32(context.Request.QueryString["recordId"]);
            Movie movie = GetMovie(recordid);
            context.Response.ContentType = movie.ImageFileType;
            context.Response.BinaryWrite(movie.ImageFile.ToArray());
            
        }        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
