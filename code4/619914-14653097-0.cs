        private static void Main(string[] args)
        {
            var yourFirstMagicNumber = -1;
            var yourSecondMagicNumber = -1;
            
            // Let's use the third argument as indicator that you need user input
            if (args.Length > 2 && "true".Equals(args[2]))
            {
                Console.WriteLine("enter magic nr 1: ");
                var firstArgument = Console.ReadLine();
                yourFirstMagicNumber = Int32.Parse(firstArgument);
                Console.WriteLine("enter magic nr 2: ");
                var secondArgument = Console.ReadLine();
                yourSecondMagicNumber = Int32.Parse(secondArgument);
            }
            else
            {
                yourFirstMagicNumber = Int32.Parse(args[0]);
                yourSecondMagicNumber = Int32.Parse(args[1]);
            }
        }
