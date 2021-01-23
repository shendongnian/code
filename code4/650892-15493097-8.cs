    JsonSerializerSettings JSsettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    };
    List<ParentObject> list = new List<ParentObject>();
    list.Add(new ChildClass() { ChildClassProp = 1 });
    list.Add(new ChildClass2() { ChildClass2Prop = 2 });
    ObjectContainer container = new ObjectContainer()
    {
        Data = list
    };
    string message = JsonConvert.SerializeObject(container,
          Newtonsoft.Json.Formatting.Indented, JSsettings);
    var objectContainer = JsonConvert.DeserializeObject<ObjectContainer>(message, JSsettings);
    if (objectContainer.Data is List<int>)
    {
        Console.Write("objectContainer.Data is List<int>");
    }
    else if (objectContainer.Data is List<ParentObject>)
    {
        Console.Write("objectContainer.Data is List<ParentObject>");
    }
    else if (objectContainer.Data is string)
    {
        Console.Write("objectContainer.Data is string");
    }
