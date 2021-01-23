    class Program
    {
        static void Main()
        {
            var program = new YOUR_PROGRAM();
            if (Environment.UserInteractive)
            {
                program.Start();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[]
                {
                    program
                });
            }
        }
    }
