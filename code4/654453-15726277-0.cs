    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ConsoleApplication4.Settings1.Default["User"]); //prints "DefaultUser"
                ConsoleApplication4.Settings1.Default["User"] = "abc";
                Console.WriteLine(ConsoleApplication4.Settings1.Default["User"]);
                ConsoleApplication4.Settings1.Default.Save();
                Console.Read();
            }
        }
    }
