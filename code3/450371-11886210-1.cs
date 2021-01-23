    private void PreparePostData(HttpWebRequest webRequest)
    {
        // Multiple Files or 1 file and body and / or parameters
        if (Files.Count > 1 || (Files.Count == 1 && (HasBody || Parameters.Any())))
        {
            webRequest.ContentType = GetMultipartFormContentType();
            using (var requestStream = webRequest.GetRequestStream())
            {
                WriteMultipartFormData(requestStream);
            }
        }
        else if (Files.Count == 1)
        {
            using (var requestStream = webRequest.GetRequestStream())
            {
                Files.Single().Writer(requestStream);
            }
        }
        PreparePostBody(webRequest);
    }
