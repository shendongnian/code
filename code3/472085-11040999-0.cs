    XElement root = XElement.Load(file); // or .Parse(string)
    var students = root.Elements("student").Select(s => new
    {
        Name = s.Get("Detail/Name", string.Empty),
        Class = s.Get("Detail/Class", string.Empty),
        Items = s.GetElements("Detail/add").Select(add => new
        {
            Key = add.Get("key", string.Empty),
            Value = add.Get("value", string.Empty)
        }).ToArray()
    }).ToArray();
