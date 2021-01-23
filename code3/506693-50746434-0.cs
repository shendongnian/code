    using System;
    using System.Web;
     
    public class windowSize : IHttpHandler , System.Web.SessionState.IRequiresSessionState  {
         
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "application/json";
             
            var json = new System.Web.Script.Serialization.JavaScriptSerializer();
            var output = json.Serialize(new { isFirst = context.Session["BrowserWidth"] == null });
            context.Response.Write(output);
             
            context.Session["BrowserWidth"] =  context.Request.QueryString["Width"]; 
            context.Session["BrowserHeight"] = context.Request.QueryString["Height"];
        }
     
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
