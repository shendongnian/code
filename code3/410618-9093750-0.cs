    string destUrl = string.Format("{0}://{1}{2}/",Request.Url.Scheme,Request.Url.Authority,Request.Url.AbsolutePath);
    if (destUrl.EndsWith("/"))
        destUrl = destUrl.TrimEnd(new char[] { '/' });
    if (!string.IsNullOrEmpty(Request.QueryString["paramName"])) {
        destUrl = string.Format("{0}?paramName={1}", destUrl, "paramValueHere");
    Response.Redirect(destUrl);
    
