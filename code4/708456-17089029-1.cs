    public string odobri(HttpRequestMessage request)
    {
        Dictionary<string, string> values = request.Content.ReadAsAsync<Dictionary<string, string>>().Result;
        RootObject c = null;
        foreach (string s in values.Values)
        {
            List<RootObject> tmp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject>>(s);
            c = tmp.First();
            break;
        }
        return c.Broj;
    }
