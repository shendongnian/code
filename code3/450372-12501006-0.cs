    	private void PreparePostData(HttpWebRequest webRequest)
		{
            // Multiple Files or 1 file and body and / or parameters
            if (Files.Count > 1 || (Files.Count == 1 && (HasBody || Parameters.Count>0)))
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
                    Files[0].Writer(requestStream);
                }
            }
			PreparePostBody(webRequest);
		}
