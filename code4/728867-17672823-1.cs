    private T GetAPIData<T>(string parameters, string methodToInvoke)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8081/api/Animals");
        //eg:- methodToInvoke='GetAmimals'
        //e.g:- input='Animal' class
        HttpResponseMessage response = client.GetAsync(methodToInvoke).Result;
        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException("Request was not successful");
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        string data = response.Content.ReadAsStringAsync().Result;
        using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(data)))
        {
            return (T)serializer.Deserialize(ms);
        }
    }
