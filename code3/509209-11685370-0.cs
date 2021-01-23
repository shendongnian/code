    public interface IMyWCFContract 
    {
        [OperationContract]
        MyObject GetMyObjectById(int Id);
    }
