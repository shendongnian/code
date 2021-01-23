    public class AspDotNetMembershipProvider
    {
        public void CreateUser(string username, string password)
        {
            string createStatus;
            Membership.CreateUser(
                username,
                password,
                username,
                null,
                null,
                true,
                null,
                out createStatus);
            // throw an exception if createStatus isn't as expected
        }
    }
