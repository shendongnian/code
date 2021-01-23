    namespace WIChart.UserControls
    {
        public class ImageHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.Clear();
                var chartCtl = (ChartCtl)LoadControl(ResolveClientUrl("ChartCtl"));
                MemoryStream ms = chartCtl.renderChart();
    
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
    
            public bool IsReusable
            {
                get { return false; }
            }
    
            #endregion
        }
    
    }
