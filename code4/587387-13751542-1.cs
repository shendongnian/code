    dynamic root = DynamicXml.Load("a.xml");
    Console.WriteLine(root.a1);
    foreach (var p in root.Parameter)
    {
        Console.WriteLine("{0}:{1}",p.ParameterName, p.ParameterValue);
    }
    Console.WriteLine(root.Parameter[0].ParameterValue);
