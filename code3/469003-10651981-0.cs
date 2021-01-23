    public class SmsHub : Hub
    {
       public Task SendMessages(string input)
       {
          // ... send sms message
    
         Caller.updateStatus('Message send!');
       }
    }
