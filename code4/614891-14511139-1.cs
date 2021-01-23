    public class HelloWorld : IMyInterface
    {
        public void Function()
        {
            Console.WriteLine("Hello World");
        }
   
        public static void Main(string[] args)
        {
            new HelloWorld().MyAction();
        }
    } 
