     public class EmailThingy
     {
         private readonly IEmailClient _client;
         public EmailThingy(IEmailClient client)
         {
              _client = client;
         }
         public void Send()
         {
              // do stuff with client
         }
     }
