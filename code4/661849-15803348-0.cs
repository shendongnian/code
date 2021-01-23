    DataContractSerializer serializer = new    DataContractSerializer(typeof(List<Dictionary<String, String>>));
    byte[] byteArr;
    using (var ms = new System.IO.MemoryStream())
    {
     serializer.WriteObject(ms, stringlist);
     byteArr = ms.ToArray();
    }
     return byteArr;
