    <%@ WebHandler Language="C#" Class="MyHandler" %>
    
    using System;
    using System.Web;
    
    public class MyHandler : IHttpHandler 
    {
        public void ProcessRequest (HttpContext ctx) 
        {
            var json = new JSONResonse()
            {
                Success = ctx.Request.QueryString["name"] != null,
                Name = ctx.Request.QueryString["name"]
            };
    
            ctx.Response.ContentType = "application/json";
            ctx.Response.Write(JsonConvert.SerialzeObject(json));
        }
     
        public bool IsReusable {
            get { return false; }
        }
    }
