    public static HtmlString Image(this HtmlHelper helper, string path, string alt)
    {
        var img = new TagBuilder("img");
        img.MergeAttribute("src", path);
        img.MergeAttribute("alt", alt);
        return new HtmlString(img.ToString(TagRenderMode.SelfClosing));
    }
