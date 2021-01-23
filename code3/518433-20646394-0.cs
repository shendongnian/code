    [HttpPost]
    public HttpResponseMessage Post(dynamic item) // Passing parameter as dynamic
    {
    JArray itemArray = item["Region"]; // You need to add JSON.NET library
    JObject obj = itemArray[0] as JObject;  // Converting from JArray to JObject
    Region objRegion = obj.ToObject<Region>(); // Converting to Region object
    }
