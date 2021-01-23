    [DataContract]
    public class ConnectionFault
    {
      [DataMember]
      public string Issue { get; set; }
      [DataMember]
      public string Details { get; set; }
    }
    
    
    [FaultContract(typeof(ConnectionFault))]
    [FaultContract(typeof(DataReaderFault))]
    [OperationContract]
    Int16 GetInStock(int productId);
    //when it's time to throw the exception
    var connectionFault = new ConnectionFault();
    connectionFault.Issue = "Problem connecting to the database";
    connectionFault.Details = ex.Message;
    throw new FaultException<ConnectionFault>(connectionFault);
