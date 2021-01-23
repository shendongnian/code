     public class SomeBL : ISomeBL               
     {               
        private IUser _userservice;               
        public SomeBL(IUserService userservice)               
        {               
          _userservice = userservice;               
        }               
        public void TestMethod()               
        {               
           IUser currentUser = _userService.GetCurrentUser();
        }
     }
    
     public interface IUserService
     {
       IUser GetCurrentUser();
     }
     
     public class UserService : IUserService
     {
       public IUser GetCurrentUser
       {
          //pull user from Thread, HttpContext.CurrentRequest, cache, session, etc.
       }
    
     }
