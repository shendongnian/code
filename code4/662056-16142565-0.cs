    public static async Task<string> LoadData(string json, string serverUrl)  
    {
        var request = (HttpWebRequest)WebRequest.Create(new Uri(Constants.LocalServer));
        request.ContentType = "application/json";
        request.Method = "POST";
        using (var requestStream = await request.GetRequestStreamAsync())
        {
            var writer = new StreamWriter(requestStream);
            writer.Write(json);
            writer.Flush();
        }
        using (var resp = await request.GetResponseAsync())
        {
            using (var responseStream = resp.GetResponseStream())
            {
                var reader = new StreamReader(responseStream);
                return  = reader.ReadToEnd();
            }
        }
    }
