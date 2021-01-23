    public class ImageHandler : IHttpHandler 
    { 
      public bool IsReusable { get { return true; } } 
      public void ProcessRequest(HttpContext ctx) 
      { 
        var myImage = function_to_read_the_image();
        ctx.Response.ContentType = "image/png"; 
        ctx.Response.OutputStream.Write(myImage); 
      } 
    }
