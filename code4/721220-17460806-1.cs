    if (!Request.IsLocal && !Request.IsSecureConnection)
    {
        if (Request.Url.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.InvariantCultureIgnoreCase))
        {
            string sNonSchemeUrl = Request.Url.AbsoluteUri.Substring(Uri.UriSchemeHttp.Length);
            // Ensure www. is prepended if it is missing
            if (!sNonSchemeUrl.StartsWith("www", StringComparison.InvariantCultureIgnoreCase)) {
                sNonSchemeUrl = "www." + sNonSchemeUrl;
            }
            string redirectUrl = Uri.UriSchemeHttps + sNonSchemeUrl;
            Response.Redirect(redirectUrl);
        }
    }
 
