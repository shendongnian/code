    public class User
    {
        // some basic validation
        public virtual void ChangeEmail(string email);
    }
    
    public class Employee : User
    {
        // validates internal email
        public override void ChangeEmail(string email);
    }
    
    public class Customer : User
    {
        // validate external email addresses.
        public override void ChangeEmail(string email);
    }
