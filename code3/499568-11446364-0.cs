    using System.Web.Security;
    
    public class MyMembershipProvider : SqlMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            if (base.ValidateUser(username, password))
            {
                // successfully logged in. add logic to increment online user count.
                
                return true;
            }
    
            return false;
        }
    
        public override int GetNumberOfUsersOnline()
        {
            // add logic to get online user count and return it.
        }
    }
