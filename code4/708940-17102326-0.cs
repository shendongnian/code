    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {          
              
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                frmsplashscreen frmSplash = new frmsplashscreen();
                frmSplash.ShowDialog();
                
                YourMDIForm frmMDI = new YourMDIForm();
                Application.Run(frmMDI);
            }
            catch (Exception ex)
            {           
                //Log it
                MessageBox.Show(ex.Message);
            }
        }
    }
