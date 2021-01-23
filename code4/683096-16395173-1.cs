    public class Outlook:ISender
        {
    
            public void SendEmail()
            {
                //Write implementation on how OL send email.
            }
        }
        public class OtherEmail : ISender
        {
    
            public void SendEmail()
            {
                //Write implementation on how other email send email.
            }
        }
        public interface ISender
        {
            void SendEmail();
        }
        public class EmailFactory
        {
    
            public static ISender GetEmailProvider(string type)
            {
                if (type == "outlook")
                    return new Outlook();
                return new OtherEmail();
            }
        }
 
