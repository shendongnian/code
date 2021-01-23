    public class ImageHandler : IHttpHandler
    {
        byte[] bytes;
        public void ProcessRequest(HttpContext context)
        {
            int param;
            if (int.TryParse(context.Request.QueryString["id"], out param))
            {
                using (var db = new MusicLibContext())
                {
                    if (param == -1)
                    {
                        bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/add.png"));
                        context.Response.ContentType = "image/png";
                    }
                    else
                    {
                        var data = (from x in db.Images
                                    where x.ImageID == (short)param
                                    select x).FirstOrDefault();
                        bytes = data.ImageData;
                        context.Response.ContentType = "image/" + data.ImageFileType;
                    }
                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    context.Response.BinaryWrite(bytes);
                    context.Response.Flush();
                    context.Response.End();
                }
            }
            else
            {
                //image not found
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
