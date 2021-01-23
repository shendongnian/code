    public override string GetOutputCacheProviderName(HttpContext context)
    {       
        RouteCollection rc = new RouteCollection();
        MvcApplication.RegisterRoutes(rc);
        RouteData rd = rc.GetRouteData(new HttpContextWrapper(HttpContext.Current));
        if (rd == null)
            return base.GetOutputCacheProviderName(context);
        var controller = rd.Values["controller"].ToString();
        var action = rd.Values["action"].ToString();
        if (controller.Equals("Content", StringComparison.CurrentCultureIgnoreCase) 
            || controller.Equals("Scripts", StringComparison.CurrentCultureIgnoreCase) 
            || controller.Equals("Images", StringComparison.CurrentCultureIgnoreCase))
            return base.GetOutputCacheProviderName(context);
        if (controller.Equals("Account", StringComparison.CurrentCultureIgnoreCase))
            return "AccountOutputCacheProvider";
        if (controller.Equals("Something", StringComparison.CurrentCultureIgnoreCase))
            return controller + "OutputCacheProvider";
        return "CustomOutputCacheProvider";
    }
