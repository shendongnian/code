    public class ExampleHandler: IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
    	var request = context.Request;
            string fileName = (string)request.QueryString["name"];
            // your logic
            context.Response.Write(yourpath)
        }
    
        public bool IsReusable {
    	get {
    	    return false;
    	}
        }
    }
