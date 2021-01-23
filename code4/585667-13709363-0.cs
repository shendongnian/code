    var person = Deserialize<Person2>("a.txt");
---
    T Deserialize<T>(string fileName)
    {
        Type type = typeof(T);
        var obj = Activator.CreateInstance(type);
        foreach (var line in File.ReadLines(fileName))
        {
            if (String.IsNullOrWhiteSpace(line)) continue;
            var keyVal = line.Split('=');
            var prop = type.GetProperty(keyVal[0]);
            prop.SetValue(obj, Convert.ChangeType(keyVal[1], prop.PropertyType));
        }
        return (T)obj;
    }
