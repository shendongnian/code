    private void BlaBla()
    {
        // call the replacing function
        Uri myNewUrl = ConvertHttpToHttps(myOriginalUrl);
    }
    private Uri ConvertHttpToHttps(Uri originalUri)
    {
        Uri result = null;
        int httpsPort = 443;// if needed assign your own value or implement it as parametric 
        string resultQuery = string.Empty;
        NameValueCollection urlParameters = HttpUtility.ParseQueryString(originalUri.Query);
        if (urlParameters != null && urlParameters.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in urlParameters)
            {
                if (sb.Length > 0)
                    sb.Append("&");
                string value = urlParameters[key].Replace("http://", "https://");
                string valuEscaped = Uri.EscapeDataString(value);// this is important
                sb.Append(string.Concat(key, "=", valuEscaped));
            }
            resultQuery = sb.ToString();
        }
        UriBuilder resultBuilder = new UriBuilder("https", originalUri.Host, httpsPort, originalUri.AbsolutePath);
        resultBuilder.Query = resultQuery;
        result = resultBuilder.Uri;
        return result;
    }
