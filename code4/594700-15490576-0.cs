    [ServiceContract]
    public interface IMyQuery
    {
        [OperationContract]
        [WebGet]
        public IQueryable<Table> Query1()
    }
    
