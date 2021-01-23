    DataContractJsonSerializer serializer 
      = new DataContractJsonSerializer(typeof(CustomerStatuses));
    MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonText));
    CustomerStatuses parser = (CustomerStatuses)serializer.ReadObject(stream);
    String guid = parser.DocumentStatuses.FirstOrDefault().Guid;
    int status = parser.DocumentStatuses.FirstOrDefault().Status;
