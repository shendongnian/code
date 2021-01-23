    using Newtonsoft.Json; 
    using Newtonsoft.Json.Serialization;
 
    . . .
    private User LoadUserFromJson(string response) 
    {
        JsonSerializerSettings serSettings = new JsonSerializerSettings();
        serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        User outObject = JsonConvert.DeserializeObject<User>(jsonValue, serSettings);
        return outObject; 
    }
