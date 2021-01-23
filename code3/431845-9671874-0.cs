    private MyContext context = new MyContext()
    private IEnumerable<User> getUser(Guid userID)
    {
        return context.User.Where(c => c.ID == userID);  
    }
    
    private void evaluateUser()
    {
        bool isUserActive getUser().Any(c => c.IsActive)
    }
