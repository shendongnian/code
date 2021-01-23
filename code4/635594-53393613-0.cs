    Name Space : using System.Dynamic;
    
    public static JObject CamelCaseData(JObject jObject) {
    
        var expandoConverter = new ExpandoObjectConverter();
        
        dynamic camelCaseData = JsonConvert.DeserializeObject(jObject.ToString(), expandoConverter);
        
        return JObject.FromObject(camelCaseData, DataResponseHelper.FormattingData());
    
    }
