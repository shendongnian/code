    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    dictionary.Add("k1", "valu1");
    dictionary.Add("k2", "valu2");
    System.Runtime.Serialization.DataContractSerializer serializer = new    System.Runtime.Serialization.DataContractSerializer(typeof(Dictionary<string, string>));
    System.IO.MemoryStream stream = new System.IO.MemoryStream();
    serializer.WriteObject(stream, dictionary);
    System.IO.StreamReader reader = new System.IO.StreamReader(stream);
    stream.Position = 0;
    string xml = reader.ReadToEnd();
