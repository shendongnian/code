        public void MakeRequest(string url, string verb, Dictionary<string, string> requestParams,
            Action<string> onSuccess, Action<Exception> onError)
        {
            var paramsFormatted = string.Join("&", requestParams.Select(x => x.Key + "=" + Uri.EscapeDataString(x.Value)));
            if (verb == "GET")
            {
                url = url + (string.IsNullOrEmpty(paramsFormatted) ? "" : "?" + paramsFormatted);
            }
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = verb;
            requestParams = requestParams ?? new Dictionary<string, string>();
            Action goRequest = () => MakeRequest(request, 
                response =>
                {
                    onSuccess(response);
                },
                error =>
                {
                    if (onError != null)
                    {
                        onError(error);
                    }
                });
            if (request.Method == "POST")
            {
                request.BeginGetRequestStream(ar =>
                {
                    using (Stream postStream = request.EndGetRequestStream(ar))
                    {
                        byte[] byteArray = Encoding.UTF8.GetBytes(paramsFormatted);
                        postStream.Write(byteArray, 0, paramsFormatted.Length);
                    }
                    goRequest();
                }, request);
            }
            else // GET
            {
                goRequest();
            }
        }
        private void MakeRequest(HttpWebRequest request, Action<string> onSuccess, Action<Exception> onError)
        {
            request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream);
                            onSuccess(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    onError(ex);
                }
            }, null);
        }
