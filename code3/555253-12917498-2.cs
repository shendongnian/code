    string GetPortalAlias()
    {
        var rawUrl = Request.Url.ToString();
        var lowerTrimmedUrl = rawUrl.ToLower().Trim();
        var withoutPortUrl = lowerTrimmedUrl.Replace(":80", "");
        var withoutProtocolUrl = withoutPortUrl.Replace("http://", "");
        var justHostUrl = withoutProtocolUrl.Remove(myURL.IndexOf("/"));
        var evolution = new StringBuilder();
        evolution.AppendFormat(
            "{0}<br>", 
            HttpUtility.HtmlEncode(rawUrl));
        evolution.AppendFormat(
            "{0}<br>",
            HttpUtility.HtmlEncode(lowerTrimmedUrl));
        evolution.AppendFormat(
            "{0}<br>",
            HttpUtility.HtmlEncode(withoutPortUrl));
        evolution.AppendFormat(
            "{0}<br>",
            HttpUtility.HtmlEncode(withoutProtocolUrl));
        evolution.AppendFormat(
            "{0}<br>",
            HttpUtility.HtmlEncode(justHostUrl));
        URLLabel.Text = evolution.ToString();
        return justHostUrl;
    }
