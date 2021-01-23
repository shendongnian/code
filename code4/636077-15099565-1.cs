    public async Task<Dictionary<string, object>> CreateWebRequest(string endPoint, string method, string data, bool addAuthHeader)
    {
        WebClient client = new WebClient();
        
        if (addAuthHeader)
        {
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _accessToken.AccessToken);
        }
        byte[] buffer = null;
        
        if (!string.IsNullOrEmpty(data))
        {
            var utfenc = new UTF8Encoding();
            buffer = utfenc.GetBytes(data);
        }
        else
        {
            buffer = new byte[0];
        }
        return await client.UploadDataTaskAsync(endPoint, method, buffer)
            .ContinueWith((bytes) =>
                {
                    string jsonResponse = null;
                    using (var reader = new StreamReader(new MemoryStream(bytes)))
                    {
                        jsonResponse = reader.ReadToEnd();
                    }
                    return DeserializeResponse(jsonResponse);
                });
        }
    }
