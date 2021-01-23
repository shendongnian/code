    public class FakeMembershipProvider : MembershipProvider
    {
       public MembershipCreateStatus CreateStatus = MembershipCreateStatus.Success;
 
       public void CreateUser((string username, string password, string email, 
           string passwordQuestion, string passwordAnswer, bool isApproved, 
           object providerUserKey, out MembershipCreateStatus status)
       {
          status = CreateStatus;
       }
       ...
    }
