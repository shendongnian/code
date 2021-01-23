    public interface IUser
    {
        // ... other required User method/property signatures
        bool IsAuthorized { get; }
    }
    
    public class User : IUser
    {
        // other method/property implementations
    
        public bool IsAuthorized
        {
            get { // implementation logic here }
        }
    }
    
    public class NullUser : IUser
    {
        public bool IsAuthorized
        {
            get { return false; }
        }
    }
