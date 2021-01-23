    public class Handler : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
    
        string someparamreturned = context.Request.Params["somekey"];
        //etc.. do something
        }
    
        public bool IsReusable {
    	get {
    	    return false;
    	}
        
    }
