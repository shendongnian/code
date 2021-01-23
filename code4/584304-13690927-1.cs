    var jsonObject = JObject.Parse(json);
    
    foreach (var obj in jsonObject)
    {
        Process(obj.Value);
    }
    XDocument document = JsonConvert.DeserializeXNode(jsonObject.ToString());
    ....
    private static void Process(JToken jToken)
    {
        if (jToken.Type == JTokenType.Property)
        {
            JProperty property = jToken as JProperty;
            int value;
            
            if (int.TryParse(property.Name, out value))
            {
                JToken token = new JProperty("_" + property.Name, property.Value);
                jToken.Replace(token);
            }
        }
        
        if (jToken.HasValues)
        {
            //foreach won't work here as the call to jToken.Replace(token) above
            //results in the collection modifed error.
            for(int i = 0; i < jToken.Values().Count(); i++)
            {
                JToken obj = jToken.Values().ElementAt(i);
                Process(obj);
            }
        }
    }
