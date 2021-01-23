    Abstract theAbstract = Activator.CreateInstance<Abstract>();
    MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes("the above JSON text"));
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(theAbstract.GetType());
    theAbstract = (Abstract)serializer.ReadObject(memoryStream);
    memoryStream.Dispose();
  
