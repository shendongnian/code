    dynamic jsonObj = JsonUtils.JsonObject.GetDynamicJsonObject(json);
    foreach(var item in jsonObj)
    {
        Console.WriteLine(item.delivery_line_1 + ", " + 
                          item.last_line + ", " +
                          item.metadata.county_name + ", " +
                          item.components.street_name + ", " + 
                          item.components.city_name  );
            
    }
