    StringBuilder postData = new StringBuilder();
    postData.AppendUrlEncoded("username", uname, true);
    postData.AppendUrlEncoded("password", pword, true);
    postData.AppendUrlEncoded("url_success", urlSuccess, true);
    postData.AppendUrlEncoded("url_failed", urlFailed);
    //in an extension class
    public static void AppendUrlEncoded(this StringBuilder sb, string name, string value, bool moreValues = true)
    {
        sb.Append(HttpUtility.UrlEncode(name));
        sb.Append("=");
        sb.Append(HttpUtility.UrlEncode(value));
        if (moreValues)
          sb.Append("&");
    }
