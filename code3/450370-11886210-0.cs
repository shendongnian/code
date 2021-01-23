    private void PreparePostData(HttpWebRequest webRequest)
    {
        if (HasFiles)
        {
            webRequest.ContentType = GetMultipartFormContentType();
            using (var requestStream = webRequest.GetRequestStream())
            {
                WriteMultipartFormData(requestStream);
            }
        }
        PreparePostBody(webRequest);
    }
