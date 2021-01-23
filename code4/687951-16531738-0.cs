        public class CustomMembershipProvider : MembershipProvider
        {
              public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, stringpasswordAnswer , bool isApproved, object providerUserKey, ref MembershipCreateStatus  status)
              {
                  status = default(MembershipCreateStatus);
                  return default(MembershipUser);
              }          
              public override MembershipUser GetUser(string username, bool login)
              {
                  return default(MembershipUser);
              }
              public override bool DeleteUser(string username, bool deleteRelatedData)
              {
                  return default(bool);
              }
         } 
