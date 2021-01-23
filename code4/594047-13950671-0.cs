    public class Program
    {
        public static void Main(string[] args)
        {
            // Connect to the service
            var hubConnection = new HubConnection("http://localhost/mysite");
    
            // Create a proxy to the chat service
            var chat = hubConnection.CreateHubProxy("chat");
    
            // Print the message when it comes in
            chat.On("addMessage", message => Console.WriteLine(message));
    
            // Start the connection
            hubConnection.Start().Wait();
    
            string line = null;
            while((line = Console.ReadLine()) != null)
            {
                // Send a message to the server
                chat.Invoke("Send", line).Wait();
            }
        }
    }
