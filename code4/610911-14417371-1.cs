    string json = @"{ ""birthday"": ""1988-03-18"", ""address"": { ""state"": 24, ""city"": 8341, ""country"": 1 } }";
    var jObj = (JObject)JsonConvert.DeserializeObject(json);
    Sort(jObj);
    string newJson = jObj.ToString();
---
    void Sort(JObject jObj)
    {
        var props = jObj.Properties().ToList();
        foreach (var prop in props)
        {
            prop.Remove();
        }
        foreach (var prop in props.OrderBy(p=>p.Name))
        {
            jObj.Add(prop);
            if(prop.Value is JObject)
                Sort((JObject)prop.Value);
        }
    }
