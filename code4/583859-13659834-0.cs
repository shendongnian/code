    List<dynamic> pe = new List<dynamic>();
    
    foreach(var page in responsePages.Values)
    {
       //ToString is overridden in JsonValue to provide a string in Json format
       string pageAsJsonString = page.ToString();
       
       //Desirialize (parse) using Json.Net's JObject.Parse static method
       dynamic parsedPage = JObject.Parse(pageAsJsonString);
       pe.Add(parsedPage);
    }
    
    foreach(dynamic page in pe)
    {
       Console.WriteLine(page.name);
    }
