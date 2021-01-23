    public static HtmlString Script<T>(this HtmlHelper<T> html, string path)
    {
        var file = html.ViewContext.HttpContext.Server.MapPath(path);
        DateTime lastModified = File.GetLastWriteTime(file);
        TagBuilder builder = new TagBuilder("script");
        builder.Attributes["src"] = path + "/" + lastModified.ToString("yyyyMMddhhmmss");
        return new HtmlString(builder.ToString());
    }
