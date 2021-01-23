    using System;
    using System.Web;
    
    public class getmyimage : IHttpHandler 
    {
      public void ProcessRequest(HttpContext context)
      {
            Response.ContentType = "image/png";
            Response.WriteFile("x:\myimages\test.png");
            Response.End();
      }
    
      public bool IsReusable 
      {
        get 
        {
          return false;
        }
      }
    }
