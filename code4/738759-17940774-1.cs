    public class Email
    {
        public Email(string email)
        {
            Address = email;
            int index = email.IndexOf('@');
            UserName = email.Substring(0, index);
            Domain = email.Substring(index + 1);
        }
    
        public string Address { get; private set; }    
        public string UserName { get; private set; }    
        public string Domain { get; private set; }
    }
