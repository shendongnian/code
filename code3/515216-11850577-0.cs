    [ServiceContract]
    public interface IService1
    {
        [OperationContract(Name="GetDataUsingDataContractInput")]   
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }
