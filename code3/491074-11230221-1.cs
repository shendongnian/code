    public enum RepoFactory
    {
    	Foo, Bar, Etc,
    }
    
    [ServiceContract]
    public interface IBankAccountService
    {
        [OperationContract]
        void FreezeAllAccountsForUser(int userId, RepoFactory repoFactory);
    }
