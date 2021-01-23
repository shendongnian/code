       DTO Test = new DTO
       {
           Number = 42,
           Title = "SuperPuper",
           CustomFields = new Dictionary<string, string> { { "Description", "HelloWorld" }, { "Color", "Red" } }
       };
        String Json = Newtonsoft.Json.JsonConvert.SerializeObject(Test);
        Json = Json.Replace("\"CustomFields\":{", "");
        Json = Json.Replace("}}", "}");
