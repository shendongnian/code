        static void Main()
        {
            string sUserInput;
            int iUserNum1 = 0;
            int iUserNum2 = 0;
            int iPower = 0;
            Console.Write("Enter a number : ");
            sUserInput = Console.ReadLine();
            iUserNum1 = Int32.Parse(sUserInput); // iUserNum1 is declared as 'int' so Int32.Parse()
            Console.Write("Enter a number to waise power to :");
            sUserInput = Console.ReadLine();
            iUserNum2 = Int32.Parse(sUserInput); // iUserNum2 is declared as 'int' so Int32.Parse()
            iPower = PowerOf(iUserNum1, iUserNum2);
            Console.WriteLine(iUserNum1 + " To the power of " + iUserNum2 + " = " + iPower);
            Console.ReadLine();
        }
