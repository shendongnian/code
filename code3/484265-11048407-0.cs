    static class Program
    {
         public static bool isValid = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    		using (FrmLogin login = new FrmLogin())
    		{ 
    			login.ShowDialog(); 
    			if (isValid)
    			{           
    				Application.Run(new MainForm());
    			}
    		}
        }
    }
    
