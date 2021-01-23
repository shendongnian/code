    public interface IUserProvider 
    {
      IIdentity Identity { get; }
    }
    public class UserProvider : IUserProvider
    {
      public IIdentity Identity 
      {
        get { return ServiceSecurityContext.Current.Identity; }
      }
    }
