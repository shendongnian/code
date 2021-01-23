    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //code in OnStartUp
            Application.Run(new Form1());
            Application.ApplicationExit += Application_ApplicationExit;
        }
    
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
