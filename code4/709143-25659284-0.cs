    public static string HtmlEncode (string text)
    {
        string result;
        using (StringWriter sw = new StringWriter())
        {
            var x = new HtmlTextWriter(sw);
            x.WriteEncodedText(text);
            result = sw.ToString();
        }
        return result;
    }
