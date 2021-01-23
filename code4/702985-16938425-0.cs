    public class Handler : IHttpHandler {
        public void ProcessRequest (HttpContext context) {
	
            context.Response.ContentType = "image/jpeg"; // or whatever the content-type of the image really is.
        
			Byte[] image = GetImageFromDatabase(context.Request.QueryString["userId"]);
        
			context.Response.Write( image ); // psuedo-code
		}
		public bool IsReusable {
			get {
				return false;
			}
		}
	}
