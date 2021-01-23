    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            long id = Convert.ToInt64(System.Web.HttpContext.Current.Request.QueryString["id"]);
            string model = (System.Web.HttpContext.Current.Request.QueryString["model"]);
            DbContext Db = new DbContext();
            byte[] picture = new byte[0];
            switch (model)
            {
                case "News":
                    NameSpace.Models.News news = Db.Newss.Single<NameSpace.Models.News>(n => n.ID == id);
                    picture = news.Picture;
                    break;
                case "Article":
                    NameSpace.Models.Article article = Db.Articles.Single<NameSpace.Models.Article>(a => a.ID == id);
                    picture = article.Picture;
                    break;
            }
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(picture);
            context.Response.Flush();
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
