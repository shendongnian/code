    public interface ISecurityPolicy
    {
        public int MinimumSecurityQuestionResponses { get; }
    }
    public class User
    {
        public void HasCompletedSecurity (ISecurityPolicy security_policy)
        {
             return this.SecurityQuestionResponses.Count()
                         >= security_policy.MinimumSecurityQuestionResponses;
        }
    }
