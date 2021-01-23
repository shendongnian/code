    [ServiceContract]
    public interface IMyServices : IDisposable
    {
        [OperationContract]
        IEnumerable<Allocation> GetAllocations();
	}
	
