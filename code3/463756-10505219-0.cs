    public static string FooMethod(string path)
    {
        var htmlGenericControl = new HtmlGenericControl();
        var mappedPath = htmlGenericControl.MapPath(path);
        return mappedPath;
    }
