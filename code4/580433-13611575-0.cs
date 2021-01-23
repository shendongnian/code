    var provider = new RSACryptoServiceProvider();
    
    var parameters = provider.ExportParameters(true);
    
    var x = new XmlSerializer(parameters.GetType());
    x.Serialize(Console.Out, parameters);
    Console.WriteLine();
