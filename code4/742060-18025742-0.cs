    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMessage(new OtherMessage()));
    
            Console.WriteLine(GetMessage<OtherMessage>());
    
            Console.WriteLine(GetMessage<DefaultMessage>());
    
            Console.ReadLine();
        }
    
        public static string GetMessage<TD>(TD myMessage = null) where TD : class, IMyInterface, new()
        {
            if (myMessage == null) myMessage = new TD();
            return myMessage.Message();
        }
    }
    
    public  interface IMyInterface
    {
        string Message();
    }
    
    public class DefaultMessage : IMyInterface
    {
        public string Message()
        {
            return "Hello world!";
        }
    }
    
    public class OtherMessage : IMyInterface
    {
        public string Message()
        {
            return "Other message!";
        }
    }
