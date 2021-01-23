    [ServiceContract]
    [ServiceKnownType(typeof(YourCustomer))]
    public interface IYourService
    {
        [OperationContract]
        Object GetCustomersObject();
    }
