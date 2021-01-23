        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewBag.LanguageId = requestContext.RouteData.Values["languageId"] ?? NamedConsts.DefaultLangId;
        }
