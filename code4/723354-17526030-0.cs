    private String SendRequest(String jsonRequest)
        {
            WebRequest webRequest = WebRequest.Create(_url);
            byte[] paramBytes = Encoding.UTF8.GetBytes(jsonRequest);
            String jsonResponse;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = paramBytes.Length;
            webRequest.Headers.Add("X-Transmission-Session-Id", _sessionId);
            using (Stream oStream = webRequest.GetRequestStream())
            {
                oStream.Write(paramBytes, 0, paramBytes.Length);
                oStream.Close();
            }
            WebResponse webResponse = webRequest.GetResponse();
            using (Stream iStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(iStream, Encoding.UTF8);
                jsonResponse = reader.ReadToEnd();
                reader.Close();
                iStream.Close();
            }
            return jsonResponse;
        }
