    foreach (KeyValuePair<string, string> pair in ListParams)
    {
        System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">",
        pair.Key,
        pair.Value));
    }
