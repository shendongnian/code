        static void Main(string[] args)
        {
            string a;
            if(args.Length == 0)
            {
                 Console.Write("Please enter a string : ");
                 a = Console.ReadLine();
            }
            else
                 a = args[0];
            Console.WriteLine("You have entered: {0}", a);
            Console.ReadKey();
        }
