    public async Task GetEnvironmentVeriblesAsync(Action<Credentials> getResultCallback, Action<Exception> getErrorCallback)
    {
        CredentialsCallback = getResultCallback;
        ErrorCallback = getErrorCallback;
        var uri = new Uri(BaseUri);
        var request = (HttpWebRequest) WebRequest.Create(uri);
        request.Method = "POST";
        request.ContentType = "application/json";
        var jsonObject = new JObject
        {
            new JProperty("apiKey",_api),
            new JProperty("affiliateId",_affid),
        };
        var serializedResult = JsonConvert.SerializeObject(jsonObject);
        byte[] requestBody = Encoding.UTF8.GetBytes(serializedResult);
        // ASYNC: using awaitable wrapper to get request stream
        using (var postStream = await request.GetRequestStreamAsync())
        {
            // Write to the request stream.
            postStream.Write(requestBody, 0, requestBody.Length);
        }
        try
        {
            // ASYNC: using awaitable wrapper to get response
            var response = (HttpWebResponse) await request.GetResponseAsync();
            if (response != null)
            {
                var reader = new StreamReader(response.GetResponseStream());
                // ASYNC: using StreamReader's async method to read to end, in case
                // the stream i slarge.
                string responseString = await reader.ReadToEndAsync();
                Credentails = JsonConvert.DeserializeObject<Credentials>(responseString);
                if (Credentails != null && string.IsNullOrEmpty(Credentails.Err))
                    CredentialsCallback(Credentails);
                else
                {
                    if (Credentails != null)
                        ErrorCallback(new Exception(string.Format("Error Code : {0}", StorageCredentails.Err)));
                }
            }
        }
        catch (WebException we)
        {
            var reader = new StreamReader(we.Response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            Debug.WriteLine(responseString);
            ErrorCallback(we);
        }
    }
