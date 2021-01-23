    class Program
    {
        static void Main(string[] args)
        {
            MessageHandlerRegistry.Subscribe((Message m) => Console.WriteLine("Message received."));
            MessageHandlerRegistry.Publish(new Message());
        }
    }
