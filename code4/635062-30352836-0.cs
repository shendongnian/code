    bundles.Add(
    new StyleBundle("~/Content/Styles/base-bundle.css")
    .Include("~/Content/Styles/style.css", new CssRewriteUrlTransform())
    .Include("~/Content/Styles/normalize.css", new CssRewriteUrlTransform())
    .Include("~/Content/Styles/webfont.css", new CssRewriteUrlTransform())
    );
