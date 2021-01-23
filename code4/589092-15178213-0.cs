        private string EncodeParameters(ICollection<KeyValuePair<string, string>> parameters)
        {
            string ret = "";
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                ret += string.Format("{0}={1}&", pair.Key, pair.Value);
            }
            ret = ret.TrimEnd('&');
            return ret;
        }
        public string GetResponse(string uri, ICollection<KeyValuePair<string, string>> parameters, RequestMethods method = RequestMethods.POST)
        {
            return GetResponse(uri, EncodeParameters(parameters), method);
        }
        public string GetResponse(string uri, string data = "", RequestMethods method = RequestMethods.GET)
        {
            System.Diagnostics.Trace.WriteLine(uri);
            // create request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.PreAuthenticate = true;
            request.Method = method.ToString().ToUpper();
            request.ContentType = "application/x-www-form-urlencoded";
            // log in
            string authInfo = API_KEY + ":" + ""; // blank password
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            // send data
            if (data != "")
            {
                byte[] paramBytes = Encoding.ASCII.GetBytes(data);
                request.ContentLength = paramBytes.Length;
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(paramBytes, 0, paramBytes.Length);
                reqStream.Close();
            }
            // get response
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                throw new Exception(uri + " caused a " + (int)response.StatusCode + " error.\n" + response.StatusDescription);
            }
        }
