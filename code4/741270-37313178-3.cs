<PRE>
I have a static method for this purpose:
    // Combines urls like System.IO.Path.Combine
    // Usage: this.Literal1.Text = CommonCode.UrlCombine("http://stackoverflow.com/", "/questions ", " 372865", "path-combine-for-urls");
    public static string UrlCombine(params string[] urls) {
        string retVal = string.Empty;
        foreach (string url in urls)
        {
            var path = url.Trim().TrimEnd('/').TrimStart('/').Trim();
            retVal = string.IsNullOrWhiteSpace(retVal) ? path : new System.Uri(new System.Uri(retVal + "/"), path).ToString();
        }
        return retVal;
    }
</PRE>
