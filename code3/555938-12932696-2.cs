    class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    foreach (var arg in args)
                    {
                        Console.WriteLine(arg);
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("NO ARGS");
                    var fileName = Console.ReadLine();
                    Main(new string[] { fileName });
                }
            }
        }
