    var person = Deserialize<Person2>("a.txt");
---
    T Deserialize<T>(string fileName)
    {
        Type type = typeof(T);
        var obj = Activator.CreateInstance(type);
        foreach (var line in File.ReadLines(fileName))
        {
            var keyVal = line.Split('=');
            if (keyVal.Length != 2) continue;
            var prop = type.GetProperty(keyVal[0].Trim());
            if (prop != null)
            {
                prop.SetValue(obj, Convert.ChangeType(keyVal[1], prop.PropertyType));
            }
        }
        return (T)obj;
    }
