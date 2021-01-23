    public static string Serialize<T>(T o)
    {
        using (var sw = new StringWriter())
        {
            using (var xw = XmlWriter.Create(sw))
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(xw, o);
                return sw.ToString();
            }
        }
    }
    ...
    // we don't need to explicitly define MyClass as the type, it's inferred
    var a = XmlHelper.Serialize(new MyClass{ Property1 = "a", Property2 = 3 });
    var b = XmlHelper.Deserialize<MyClass>(a);
