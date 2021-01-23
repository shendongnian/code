    public static string FooMethod(string path)
    {
        var htmlGenericControl = new System.Web.UI.HtmlControls.HtmlGenericControl();
        var mappedPath = htmlGenericControl.MapPath(path);
        return mappedPath;
    }
