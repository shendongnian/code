    public class DoublePasswordProvider : SqlMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            if (checkPIN(username, password)) return true;
            return base.ValidateUser(username, password);
        }
    }
