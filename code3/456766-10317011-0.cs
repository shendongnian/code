    interface IStatusItem
    {
       void SendEmails(EmailService service);
    }
    
    public class Product : IStatusItem
    {
       public void SendEmails(EmailService service)
       {
          // Send Email
       }
    }
    
    public class Application : IStatusItem
    {
       public void SendEmails(EmailService service)
       {
          // Send Email
       }
    }
