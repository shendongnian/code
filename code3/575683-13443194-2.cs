    public class Sms : IMessage
    {
        // do not use explicit implementation 
        // unless you need to have methods with same signature
        // or you want to hide interface implementation
        public void Get()
        {
            Console.WriteLine("Message Get!");
        }
        public void Send()
        {
            Console.WriteLine("Message Send!");
        }
    }
