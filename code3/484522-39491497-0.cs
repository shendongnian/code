    string url = HttpContext.Current.Request.Url.AbsoluteUri;
    string[] separateURL = url.Split('?');
    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]);
    queryString.Remove("param_toremove");
    string revisedurl = separateURL[0] + "?" + queryString.ToString();
