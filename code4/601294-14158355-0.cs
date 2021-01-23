    public interface IRepository 
    {
        IEnumerable<Something> GetUsers();
    }
    public class ActiveDirectoryRepository : IRepository ...
    
    public class AnotherRepository : IRepository ...
