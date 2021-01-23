    public static string Image(this HtmlHelper htmlHelper, string path, string alt)
    {
        var img = new TagBuilder("img");
        img.MergeAttribute("src", path);
        img.MergeAttribute("alt", alt);
        return img.ToString(TagRenderMode.SelfClosing);
    }
