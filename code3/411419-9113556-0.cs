    public interface IUserList
    {
       List<User> Users { get; }
    }
    
    public class SUT
    {
       private IUserList UserList { get; set; }
    
       public SUT(IUserList userList)
       {
         this.UserList = userList;
       }
    }
    
    public class AppUserList : IUserList
    {
       public List<User> Users
       {
          get
          {
             return ((App)App.Current).Users;
          }
       }
    }
