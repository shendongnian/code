    public class SocialSharingHandler : IHttpHandler 
     {
    	public void ProcessRequest(HttpContext context)
    	{
    		 string method = (string)context.Request.QueryString["m"];
    		 if (!string.IsNullOrEmpty(method))
    		 {
    			  MethodInfo methodInfo = typeof(SocialSharingHandler).GetMethod(method);
    			  methodInfo.Invoke(new SocialSharingHandler(), new object[] { context.Request.Form });
    		 }     
    	 } 
     }  
