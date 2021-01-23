    public class EnterUserNameModule : ConsoleModule
    {
        public EnterUserNameModule()
        {
            Id = 2;
            DisplayName = "User Name";
        }
        public static string UserName { get; set; }
        public override void Execute()
        {
            Console.WriteLine("Please Enter Your Name: ");
            UserName = Console.ReadLine();
        }
    }
    public class HelloWorldModule: ConsoleModule
    {
        public HelloWorldModule()
        {
            Id = 1;
            DisplayName = "Hello, World!";
        }
        public override void Execute()
        {
            Console.WriteLine("Hello, " + (EnterUserNameModule.UserName ?? "World") + "!");
        }
    }
    public class SumModule: ConsoleModule
    {
        public SumModule()
        {
            Id = 3;
            DisplayName = "Sum";
        }
        public override void Execute()
        {
            int number = 0;
            Console.Write("Enter A Number: ");
            if (int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("Your number plus 10 is: " + (number + 10));
            else
                Console.WriteLine("Could not read your number.");
        }
    }
