        public static HtmlHelper<object> CurrentHtml(this HtmlHelper html)
        {
            var ch = (HtmlHelper<object>)HttpContext.Current.Items["currentHtml"];
            if (ch == null)
            {
                var context = new HttpContextWrapper(HttpContext.Current);
                var routeData = new RouteData();
                routeData.Values["controller"] = "Home";    // you can use any controller here
                var controllerContext = new ControllerContext(new RequestContext(context, routeData), new HomeController());
                var view = ViewEngines.Engines.FindView(controllerContext, "Index", null);
                ch = new HtmlHelper<object>(new ViewContext(controllerContext, view.View, new ViewDataDictionary(), new TempDataDictionary(), TextWriter.Null), new ViewPage());
                HttpContext.Current.Items["currentHtml"] = ch;
            }
            return ch;
        }
