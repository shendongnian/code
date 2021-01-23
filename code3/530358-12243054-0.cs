    dynamic dynObj = JsonConvert.DeserializeObject(json);
    foreach (var events in dynObj.Categories.Types.Events)
    {
        foreach (var ne in events.NumberEvent)
        {
            Console.WriteLine("{0}",(string)ne["event"]);
        }
                
    }
