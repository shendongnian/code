    I am thinking of below solution:
    Interface IMessageSystem
    {
    void Send();
    }
    Public class Email : IMessageSystem
    {
       public void Send()
      {
        console.writeline("Message From Email");
      }
    }
    Public class SMS : IMessageSystem
    {
       public void Send()
      {
        console.writeline("Message From SMS");
      }
    }
    Public class Twitter : IMessageSystem
    {
       public void Send()
      {
        console.writeline("Message From Twitter");
      }
    }
    Interface ISendMessageStrategy
    {
      void SendMessages();
    }
    Public class SendMessageStrategyForRoleA : ISendMessageStrategy
    {
       Public void SendMessages()
      {
        Email objemail = new Email();
       objemail.Send();
       SMS objSMS = new SMS();
       objSMS .Send();
       Twitter objtwitter = new Twitter();
       objtwitter.Send();   
      }
    }
    Public class SendMessageStrategyForRoleB : ISendMessageStrategy
    {
       Public void SendMessages()
      {
       SMS objSMS = new SMS();
       objSMS .Send();
      }
    }
    Public class SendMessageStrategyForRoleC  : ISendMessageStrategy
    {
      Public void SendMessages()
      {  
        Twitter objtwitter = new Twitter();
        objtwitter.Send();
      }
    }
    Public class SendMessageSystem
    {    
       public ISendMessageStrategy sendMessageStrategy;
       List<Keyvaluepair<string,ISendMessageStrategy>> lstkeyval = new List<Keyvaluepair<string,ISendMessageStrategy();
       public SendMessageSystem(string role)
       {
           lstkeyval.add(new keyvaluepair<string,ISendMessageStrategy>("A",new SendMessageStrategyForRoleA()));
           lstkeyval.add(new keyvaluepair<string,ISendMessageStrategy>("B",new SendMessageStrategyForRoleB()));
           lstkeyval.add(new keyvaluepair<string,ISendMessageStrategy>("C",new SendMessageStrategyForRoleC()));
           sendMessageStrategy = lstkeyval.where(x=>x.Key == role).Value;
       }
       public void SendMessage ()
       {
           sendMessageStrategy.SendMessages();
       }
    }
    public class programme
    {
       static void main (string[] args)
       {
         SendMessageSystem objMessage = new SendMessageSystem("A");
         objMessage.SendMessage();
       }
    }
