    public class ghCompanyLogoImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Stream objLogoStream = null;
    
            objLogoStream = GetCompanyLogo(context);
            
            if (objLogoStream != null && objLogoStream.Length > 0)
            {
                // Set up the response settings
                context.Response.ContentType = "image/jpeg";
                context.Response.BufferOutput = false;
                
                const int buffersize = 1024 * 16;
                byte[] buffer = new byte[buffersize];
                int count = objLogoStream.Read(buffer, 0, buffersize);
                while (count > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, count);
                    count = objLogoStream.Read(buffer, 0, buffersize);
                }
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    
        private Stream GetCompanyLogo(HttpContext context)
        {
            try
            {
                // Fetch image data stored in DB, convert it to MemoryStream and return it.
                // You can read querystring value here using "context.Request.QueryString[]"
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
