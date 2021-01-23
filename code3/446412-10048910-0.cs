    NameValueCollection authForm = Request.Form;
    StringBuilder sb = new StringBuilder();
    foreach (string key in authForm.AllKeys)
    {
        sb.AppendFormat(
            "Key: {0}, Value: {1}<br/>", 
            HttpUtility.HtmlEncode(key), 
            HttpUtility.HtmlEncode(authForm[key])
        );
    }
    Response.Write(sb.ToString());
