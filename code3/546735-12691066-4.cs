        public class Program
        {
            public static void Main()
            {
                Console.WriteLine("Here the app is running");
                var shared = new Shared.SharedClass();
                Console.WriteLine(shared.DoLogic(10));
                Console.ReadKey();
            }
        }
