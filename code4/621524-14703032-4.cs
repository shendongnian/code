    StringBuilder postData = new StringBuilder();
    postData.AppendUrlEncoded("username", uname);
    postData.AppendUrlEncoded("password", pword);
    postData.AppendUrlEncoded("url_success", urlSuccess);
    postData.AppendUrlEncoded("url_failed", urlFailed);
    //in an extension class
    public static void AppendUrlEncoded(this StringBuilder sb, string name, string value)
    {
        if (sb.Length != 0)
            sb.Append("&");
        sb.Append(HttpUtility.UrlEncode(name));
        sb.Append("=");
        sb.Append(HttpUtility.UrlEncode(value));
    }
