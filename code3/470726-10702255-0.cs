    public class MailMessage
    {
       public string From{get;set;}
       public string To{get;set;}
       public string Body{get;set;}
       public string Subject{get;set;}
       ....
       //other common properties you may need
    }
    //interface 
    public interface IMailService
    {
        Send(MailMessage m);
    }
