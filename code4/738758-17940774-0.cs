    public class Email
    {
        public Email(string email)
        {
            Address = email;
        }
    
        public string Address { get; private set; }
    
        public string UserName
        {
           get 
           {
               int index = Address.IndexOf('@');
               return Address.Substring(0, index);
           }
        }
    
        public string Domain
        {
           get 
           {
               int index = Address.IndexOf('@');
               return Address.Substring(index + 1);
           }
        }
    }
