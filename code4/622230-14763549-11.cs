    // Least common denominator...
    object[] tempResult;
    var assemblyStuffIsFrom = Assembly.GetExecutingAssembly();
    var allSerializableTypes = assemblyStuffIsFrom
        .GetTypes()
        .Where(t => t.GetCustomAttributes(typeof(SerializableAttribute), true).Any())
        // TODO: add as much filtering as you can here to help trim down the set
        .ToArray();
    var hope = new XmlSerializer(typeof(object[]), allSerializableTypes);
    using(var sr = new StringReader(sb.ToString()))
    using(var xr = XmlReader.Create(sr))
        tempResult = ((object[])hope.Deserialize(xr));
