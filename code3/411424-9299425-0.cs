    public interface IUserService
    {       
        // Implemented functionality as methods where possible for better
        // extendability (like IoC)
        IEnumerable<User> Users();
        // Add any other user service stuff as you see fit.
        void AddUser(User user);
    }
