    [ServiceContract(Namespace = "", Name = "CustomerInfoService")]
    public interface CustomerInfo_I
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        Customer_T CustName(string accountno);
    }
