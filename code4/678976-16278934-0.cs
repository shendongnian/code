    <%@ WebHandler Language="C#" Class="Handler" %> 
     
    using System; 
    using System.Web; 
     
    public class Handler : IHttpHandler { 
     
        public void ProcessRequest (HttpContext context) { 
     
            HttpResponse r = context.Response; 
            r.ContentType = "image/png"; 
            // 
            // Write the requested image 
            // 
            string file = context.Request.QueryString["file"]; 
     
    // Get Data From Database. And write file. 
            if (file == "logo") 
            { 
                r.WriteFile("Logo1.png"); 
            } 
            else 
            { 
                r.WriteFile("Flower1.png"); 
            } 
        } 
     
        public bool IsReusable { 
            get { 
                return false; 
            } 
        } 
    }
