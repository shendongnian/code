    Type[] types = { typeof(MyType), typeof(AnotherType), *add more here* };
            
    foreach(Type t in types)
    {
        List<string> propExample = new List<string>();
        foreach(var p in t.GetProperties())
        {
            propExample.Add(p.Name + "=value");
        }
        config.SetSampleForType(string.Join("&", propExample), new MediaTypeHeaderValue("application/x-www-form-urlencoded"), t);            
    }
