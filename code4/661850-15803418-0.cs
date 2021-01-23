    System.Runtime.Serialization.DataContractSerializer serializer = new     System.Runtime.Serialization.DataContractSerializer(typeof(List<Dictionary<String, String>>));
    List<Dictionary<String, String>> stringlist;
    using (var ms = new System.IO.MemoryStream(byteArr))
    {
    stringlist = (List<Dictionary<String, String>>)serializer.ReadObject(ms);
    }
    return stringlist;
        This code is helpful to get your data back to original state. I think this is what you are asking for
