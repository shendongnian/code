    public class StickerHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;
            //TODO: link your MyImage to iSource using imageId query parameter...
            Image iSource = null;
            MemoryStream ms = new MemoryStream();
            iSource.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] data = ms.ToArray();
            ms.Dispose();
            g.Flush();
            g.Dispose();
            iSource.Dispose();
            context.Response.BinaryWrite(data);
        }
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
