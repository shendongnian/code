    JsonSerializerSettings JSsettings = new JsonSerializerSettings
	{
		TypeNameHandling = TypeNameHandling.Objects
	};
	List<ParentObject> list = new List<ParentObject>();
	list.Add(new ChildClass() { ChildClassProp = 1 });
	list.Add(new ChildClass2() { ChildClass2Prop = 2 });
	string message = JsonConvert.SerializeObject(list,
          Newtonsoft.Json.Formatting.Indented, JSsettings);
    list = JsonConvert.DeserializeObject<List<ParentObject>>(message, JSsettings);
