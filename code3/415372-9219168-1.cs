    public class A 
    {
      IEmailSender _emailSender
      public A(IEmailSender emailSender)
      {
        _emailSender = emailSender;
      }
    
      private void SendEmail()
      { 
        _emailSender.Send();
      }
    }
