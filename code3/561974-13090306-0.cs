    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            string imageid = context.Request.QueryString["ImID"];
            using (DataContext data = new DataContext())
            {
                var image = data.Products.Where(p => p.ID.ToString() == imageid).Select(p => p.Image).Single();
                context.Response.BinaryWrite((byte[])image.ToArray());
                context.Response.End();
            }
        }
    }
