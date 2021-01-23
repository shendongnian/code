    public class Contact
    {
        public string Name { get; set; }
        public string[] Emails { get; set; }
        public string EmailsCommaSeperated 
        { 
          get
          {
            return String.Join(",",Emails);
          }
        }
    }
