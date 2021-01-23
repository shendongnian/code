    static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                // run as windows app
                Application.EnableVisualStyles();
                Application.Run(new Form1());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
