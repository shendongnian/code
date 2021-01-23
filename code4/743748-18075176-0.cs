    public class MyHub
    {
        public void Send(string message, int age)
        {
            Clients.All.send(message, age);
        }
    }
