    var main = JObject.Parse(json);
    foreach (var mainRoute in main.Properties())
    {
        Console.WriteLine(mainRoute.Name); //33, 32, ... 
        foreach (var subRoute in mainRoute.Values<JObject>().SelectMany(x => x.Properties()))
        {
            Console.WriteLine(" " + subRoute.Name); //0, 3, ... 
            var routeData = subRoute.Value as JObject;
            foreach (var dataItem in routeData.Properties())
            {
                Console.WriteLine(string.Format("  {0} = {1}", dataItem.Name, dataItem.Value.Value<string>()));
            }
        }
    }
