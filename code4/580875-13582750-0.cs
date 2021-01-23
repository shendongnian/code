      public class Chat : Hub 
      {
           public void Send(string message)
          {
              // Call the addMessage method on all clients            
              Clients.All.addMessage(message);
          }
      }
