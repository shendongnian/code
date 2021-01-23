    List<dynamic> dynamicList = new List<dynamic>();
    List<FBPage> pe = new List<FBPage>();
    
    foreach(var page in responsePages.Values)
    {
       //ToString is overridden in JsonValue to provide a string in Json format
       string pageAsJsonString = page.ToString();
       
       //Deserialize (parse) to a dynamic object using Json.Net's JObject.Parse static method
       dynamic parsedPage = JObject.Parse(pageAsJsonString);
       dynamicList.Add(parsedPage);
       //Alternatively, if you have an appropriate object handy, deserialize directly:
       FBPage deserializedPage = JsonConvert.DeserializeObject<FBPage>(pageAsJsonString);
       pe.Add(deserializedPage);
    }
    
    foreach(dynamic page in dynamicList)
    {
       Console.WriteLine(page.name);
    }
    foreach(FBPage page in pe)
    {
       Console.WriteLine(page.Id);
    }
