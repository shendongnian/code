    public static void UpdateOrAdd(this List<myobj> source, 
         string name, object value)
    {
        var obj = source.FirstOrDefault(x => x.Name == name);
        if (obj == null)
        {
            obj = new myobj { Name = name };
            source.Add(obj);
        }
       
        obj.Value = value;
    }
