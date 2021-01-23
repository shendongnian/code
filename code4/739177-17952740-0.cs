    public static void SetValue(this HiddenField c, string text)
    {
        c.Value = HttpUtility.HtmlEncode(text);
    }
    public static string GetValue(this HiddenField c)
    {
        return HttpUtility.HtmlDecode(c.Value);
    }
