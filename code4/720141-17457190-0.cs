    public OrdersController(IUserProvider userProvider)
    {
        this.userProvider = userProvider
    }
    public void DoSomething()
    {
        var user = this.userProvider.GetCurrentUser();
        if (user == null)
            RedirectToLogin();
        
        // continue doing something
    }
    public class UserProvider : IUserProvider
    {
        public User GetCurrentUser() { ... }
    }
