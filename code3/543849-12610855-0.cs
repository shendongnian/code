    string json = @"{
        ""name"": ""charlie"",
        ""num"": 123
    }";
            
    var jObj = (JObject)JsonConvert.DeserializeObject(json);
    var query = String.Join("&",
                    jObj.Children().Cast<JProperty>()
                    .Select(jp=>jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));
