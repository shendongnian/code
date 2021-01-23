    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetupInformation.PrivateBinPath = "path";
            Application.Run(new Form1());
        }
    }
