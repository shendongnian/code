    public static JsonSerializer FormattingData()
    {
       var jsonSerializersettings = new JsonSerializer {
       ContractResolver = new CamelCasePropertyNamesContractResolver() };
       return jsonSerializersettings;
    }
    public static JObject CamelCaseData(JObject jObject) 
    {   
       var expandoConverter = new ExpandoObjectConverter();
       dynamic camelCaseData = 
       JsonConvert.DeserializeObject(jObject.ToString(), 
       expandoConverter); 
       return JObject.FromObject(camelCaseData, FormattingData());
   }
