    public string GetMenu() 
    {
        XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(WebConfigHelper.GetSiteMenu));
        xmlDoc.Descendants().Where(element => !UserHelper.IsUserAuthorized(element.Attribute("roles"))).Remove();
        return XsltTransformHelper.ExecuteXslTransformation(xmlDoc.ToString(), HttpContext.Current.Server.MapPath(WebConfigHelper.GetSiteMenuTransform));
    }
