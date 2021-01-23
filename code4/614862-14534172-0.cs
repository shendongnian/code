    public string GetUrlForPage(string relativeUrl)
    {
        return string.Format(
           "{0}://{1}{2}{3}",
            Request.Url.Scheme,
            Request.Url.Host,
            Request.Url.IsDefaultPort ? string.Empty : ":" + Request.Url.Port,
            Page.ResolveUrl(relativeUrl));
    }
