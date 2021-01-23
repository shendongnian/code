    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            foreach (string str in args)
                Console.WriteLine(str);
                //Do something with the args 
 
            Application.Run(new Form1());
        }
    }
