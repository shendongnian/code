    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISampleService
    {
        [OperationContract]
        void Login(string user, string password, int entityID);
    }
