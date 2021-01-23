      class Program
       {
        static void Main(string[] args)
        {
            Console.WriteLine("basic input output");
            GetUserData();
            Console.ReadLine();
        }
        static void GetUserData()
        {
            Console.Write("please enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("please enter your age: ");
            string userAge = Console.ReadLine();
            //changes echo colour
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            //echo to console
            Console.WriteLine("hello {0}! Your are {1} years old.", userName, userAge);
            //Restore previous color
            Console.ForegroundColor = prevColor;
        }
    }
}
