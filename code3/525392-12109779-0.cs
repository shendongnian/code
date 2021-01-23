    public class MyMembershipProvider : MembershipProvider
    { 
            public override bool ValidateUser(string username, string password)
            {    
                //check user credentials
                return IsUserValid;
            }
    }
