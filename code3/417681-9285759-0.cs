    public class MyRoute : Route
    {
        private readonly ConcurrentDictionary<string, string> _slugs;
        public MyRoute(IDictionary<string, string> slugs)
            : base(
            "{slug}", 
            new RouteValueDictionary(new { controller = "categories", action = "index" }), 
            new RouteValueDictionary(GetDefaults(slugs)), 
            new MvcRouteHandler()
        )
        {
            _slugs = new ConcurrentDictionary<string, string>(slugs, StringComparer.OrdinalIgnoreCase);
        }
        private static object GetDefaults(IDictionary<string, string> slugs)
        {
            return new { slug = string.Join("|", slugs.Keys) };
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var rd = base.GetRouteData(httpContext);
            if (rd == null)
            {
                return null;
            }
            var slug = rd.Values["slug"] as string;
            if (!string.IsNullOrEmpty(slug))
            {
                string id;
                if (_slugs.TryGetValue(slug, out id))
                {
                    rd.Values["id"] = id;
                }
            }
            return rd;
        }
    }
