    using System.Web;
    using System.Web.UI;
    using System.IO;
    namespace WebApplication1
    {
        public class ImageHandler : Page, IHttpHandler
        {
            public new void ProcessRequest(HttpContext context)
            {
                context.Response.Clear();
                ChartCtl chartCtl = (ChartCtl)LoadControl(ResolveClientUrl("ChartCtl.ascx"));
                MemoryStream ms = new MemoryStream();
                ms = chartCtl.renderChart(ms);
    
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(ReadFully(ms));
                context.Response.End();
            }
    
            public static byte[] ReadFully(Stream input)
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
    
            #region IHttpHandler Members
    
            public new bool IsReusable
            {
                get { return false; }
            }
    
            #endregion
        }
    
    }
