    public class BookRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var url = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            url = url.Replace(@"~/", "");
            var book = getBookWithTheNameThatMatchesTheUrl(url);
            if (book != null)
            {
                var rd = new RouteData(this, new MvcRouteHandler());
                rd.Values.Add("controller", "Home");
                rd.Values.Add("action", "Details");
                rd.Values.Add("bookId", book.Id);
                return rd;
            }
            return null;
        }
