    public class ImageHandler : System.Web.IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Logic to get byte array here
            byte[] buffer = WhateverLogicNeeded;
            context.Response.ContentType = "image/jpeg";
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
