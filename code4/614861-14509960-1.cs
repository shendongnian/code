    public string GetUrlForPage(string page)
    {
        return MyHiddenField.Value = string.Format(
           "{0}://{1}{2}/{3}",  
            Request.Url.Scheme, 
            Request.Url.Host,
            Request.Url.IsDefaultPort ? string.Empty : ":" + Request.Url.Port,
            page);
    }
