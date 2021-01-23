    (in addition to other using statements)
    using System.IO;
    using System.Text;
    using System.Web;  
    
    protected void Application_AuthenticateRequest(object sender, EventArgs e){
    
    HttpApplication app = (HttpApplication)sender;
    // Do a quick check to make sure that we are not on local. 
    // I've had some odd errors on local, though I suspect general implementation will not have this issue.
    // So if we're actually on a 'real' (a.k.a. non-local) website, I do the following.
    
          using (var stream = new MemoryStream())
                    {
                        app.Request.InputStream.Seek(0, SeekOrigin.Begin);
                        app.Request.InputStream.CopyTo(stream);
                        string requestBody = Encoding.UTF8.GetString(stream.ToArray());
                        app.Request.InputStream.Seek(0, SeekOrigin.Begin); 
                        if (requestBody.Length > 0) Response.Write("requestBody: " + requestBody + "<br>");
                    }
    }
