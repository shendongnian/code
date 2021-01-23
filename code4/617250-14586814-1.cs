        public async void GetEnvironmentVeribles(Action<Credentials> getResultCallback, Action<Exception> getErrorCallback) {
            CredentialsCallback = getResultCallback;
            ErrorCallback = getErrorCallback;
            var uri = new Uri(BaseUri);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            var jsonObject = new JObject {
                new JProperty("apiKey", _api),
                new JProperty("affiliateId", _affid),
            };
            var serializedResult = JsonConvert.SerializeObject(jsonObject);
            var requestBody = Encoding.UTF8.GetBytes(serializedResult);
            var requestStream = request.GetRequestStream();
            requestStream.Write(requestBody, 0, requestBody.Length);
            await GetResponse(request);
        }
        private async Task GetResponse(WebRequest request) {
            Stream resStream = null;
            try {
                var response = await request.GetResponseAsync();
                if (response == null) {
                    return;
                }
                resStream = response.GetResponseStream();
                if (resStream == null) {
                    return;
                }
                var reader = new StreamReader(resStream);
                var responseString = await reader.ReadToEndAsync();
                Credentails = JsonConvert.DeserializeObject<Credentials>(responseString);
                if (Credentails != null && string.IsNullOrEmpty(Credentails.Err)) {
                    CredentialsCallback(Credentails);
                }
                else {
                    if (Credentails != null) {
                        ErrorCallback(new Exception(string.Format("Error Code : {0}", StorageCredentails.Err)));
                    }
                }
            }
            catch (WebException we) {
                if (resStream != null) {
                    var reader = new StreamReader(resStream);
                    var responseString = reader.ReadToEnd();
                    Debug.WriteLine(responseString);
                }
                ErrorCallback(we);
            }
        }
