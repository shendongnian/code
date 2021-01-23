    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                if (args.Length == 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;
                }
                else //Process command lines
                {
                    Console.WriteLine("Please enter some command.");
                    string cmd = Console.ReadLine();
                    Console.WriteLine("You entered: " + cmd);
                    if (cmd == "exit") break;
                }
            }
        }
    }
