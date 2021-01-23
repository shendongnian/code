        static void Main(string args[])
        {
            Console.WriteLine("Press A for addition");
            Console.WriteLine("Press S for subtraction");
            Console.WriteLine("Press M for Multiplication");
            Console.WriteLine("Press D for Divide");
            Console.WriteLine("Press X to exit");
            //... all the stuff up to the switch
            switch(c)
            {
                //all the cases from before
                case 'x' : exitMethod();break;
            }
        }
        private static void exitMethod()
        {
            Application.Exit();
        }
