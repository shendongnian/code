    // requires following assembly references:
    //
    //using System.Xml;
    //using System.IO;
    //using System.Runtime.Serialization;
    //using System.Runtime.Serialization.Formatters.Binary;
    //
    // Target object “obj”
    //
    long length = 0;
    
    MemoryStream stream1 = new MemoryStream();
    using (XmlDictionaryWriter writer = 
        XmlDictionaryWriter.CreateBinaryWriter(stream1))
    {
        NetDataContractSerializer serializer = new NetDataContractSerializer();
        serializer.WriteObject(writer, obj);
        length = stream1.Length; 
    }
