    internal class Program
        {
            private static void Main(string[] args)
            {
                Properties.Settings1.Default.Test = "StackOverFlow";
                Properties.Settings1.Default.Save();
                Console.ReadKey();
            }
        }
