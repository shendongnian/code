    public interface IOUProvider
    {
            IEnumerable<OUInfo> GetOUs();
    }    
    public interface IActiveDirectoryService
    {
        IOUProvider RelevantOUProvider { get; }
        IPrincipal FindPrincipals();
    }
    
    public class ActiveDirectoryService : IActiveDirectoryService
    {
           public ActiveDirectoryService(IOUProvider relevantOuProvider)
           {
           }
    }
