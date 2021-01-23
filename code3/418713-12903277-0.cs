    public class Account
    {
        //some account information and behavior
    }
    
    public interface ISecurityContext
    {
    }
        
    public class UsernamePasswordContext : ISecurityContext
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public class SessionContext : ISecurityContext
    {
        public string SessionId { get; set; }
    }
