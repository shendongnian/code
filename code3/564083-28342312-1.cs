    string Serialized = JsonConvert.SerializeObject(jsonData);
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json"); 
        var response = await client.PostAsync("http://localhost:1234", content);   
    }
