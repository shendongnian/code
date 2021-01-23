    List<string> list = new List<string>();
    list.Add("joe");
    list.Add("sam");
    
    NetDataContractSerializer ser = new NetDataContractSerializer();
    using (FileStream stream = File.OpenWrite("test.xml"))
    {
        ser.Serialize(stream, list);
    }
