    public static string FooMethod(string path)
    {
        var mappedPath = HttpContext.Current.Server.MapPath(path);
        return mappedPath;
    }
