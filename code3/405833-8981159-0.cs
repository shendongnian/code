    public class User
    {
        // properties map to columns
        // Consider using NHibernate, Entity Framework, etc.
    }
    
    // ALL database access goes through interface implementations.
    public interface IUserRepository
    {
        // One of several options - TryParse pattern
        bool TryGetById(int userId, out User user);
    }
    
    public class SomeBusinessLogic
    {
        public SomeBusinessLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public string ValidateClient(int userId)
        {
            // Probably more logic here.
            string message;
            bool result = ClientIdMatchesUserId(userId, out message);
            
            if (result)
            {
                return string.Empty;
            }
            
            return message;
        }
        
        private bool ClientIdMatchesUserId(int userId, out string message)
        {
            User user;
            bool found = _userRepository.TryGetById(userId, out user);
            
            message =
                found
                ? "ClientId matches."
                : "ClientId does not match.";
                
            return found;
        }
        
        private readonly IUserRepository _userRepository;
    }
