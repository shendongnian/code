    class Program
    {
        static void OnMessageChanged(MessageChangedEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
        static void Main(string[] args)
        {
            EventBus.Subscribe<MessageChangedEvent, MessageChangedEventArgs>(OnMessageChanged);
            EventBus.Publish<MessageChangedEvent, MessageChangedEventArgs>(new MessageChangedEventArgs{ Message = "Hello world."});
            Console.ReadKey();
        }
    }
