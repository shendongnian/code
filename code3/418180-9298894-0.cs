    public class CommandMessage
    {
        public DateTime IssuedAt
        {
            get;
            set;
        }
    }
    public class CreateOrderMessage : CommandMessage
    {
        public string CustomerName
        {
            get;
            set;
        }
    }
    public interface ICommandMessageHandler2<in T> where T : CommandMessage
    {
        void Execute(T command);
    }
    public class CreateOrderHandler2 : ICommandMessageHandler2<CreateOrderMessage>
    {
        public void Execute(CreateOrderMessage command)
        {
            // No typecast is required
            Debug.WriteLine("CustomerName: " + command.CustomerName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var message = new CreateOrderMessage
            {
                CustomerName = "ACME"
            };
            // This code throws InvalidCastException
            var handler2 = (ICommandMessageHandler2<CreateOrderMessage>)new CreateOrderHandler2();
            handler2.Execute(message);
        }
    }
