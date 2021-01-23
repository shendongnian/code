    var jObj = (System.Json.JsonObject)System.Json.JsonObject.Parse(json);
    Sort2(jObj);
    var newJson = jObj.ToString();
---
    void Sort2(System.Json.JsonObject jObj)
    {
        var props = jObj.ToList();
        foreach (var prop in props)
        {
            jObj.Remove(prop.Key);
        }
        foreach (var prop in props.OrderByDescending(p => p.Key))
        {
            jObj.Add(prop);
            if (prop.Value is System.Json.JsonObject)
                Sort2((System.Json.JsonObject)prop.Value);
        }
    }
