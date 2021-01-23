    dynamic dynObj = JsonConvert.DeserializeObject("{a:1,b:2}");
    //JContainer is the base class
    var jObj = (JObject)dynObj;
    foreach (JToken token in jObj.Children())
    {
        if (token is JProperty)
        {
            var prop = token as JProperty;
            Console.WriteLine("{0}={1}", prop.Name, prop.Value);
        }
    }
