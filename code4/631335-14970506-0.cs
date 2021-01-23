        public static void Main(String[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
        
            Console.WriteLine(@"C:\Test Folder\документи");
            // input C:\Test Folder\документи
            string strLineUserInput = Console.ReadLine();
            Console.WriteLine(strLineUserInput);
        }
