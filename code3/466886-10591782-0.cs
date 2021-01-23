    [WebMethod]
    public string GetJsonData()
    {
        JArray jArray = new JArray();
        JObject jObject = new JObject();
        jObject.Add(new JProperty("name", "value"));
        jArray.Add(jObject);
        return jArray.ToString();
    }
