    <%@ WebHandler Language="C#" Class="Download" %>
    
    using System;
    using System.Web;
    
    public class Download : IHttpHandler 
    {
        public void ProcessRequest (HttpContext context) 
        {
            context.Response.ContentType = "application/octet-stream";
            context.Response.WriteFile("~/App_Data/test.exe");
        }
    
        public bool IsReusable 
        {
    	    get 
            {
    	        return false;
    	    }
        }
    }
