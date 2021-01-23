     .
        .
       [STAThread]
        static void Main()
        { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Microsoft.Win32.SystemEvents.SessionEnded += new Microsoft.Win32.SessionEndedEventHandler(SystemEvents_SessionEnded);
    
                Program.mainWindow = new Form1();
                mainWindow.Activate();
                mainWindow.Visible = false;
                PutIcon();           
                RegisterHotKey(true);   
                Application.Run();
            }   
        }
    
        public static void SystemEvents_SessionEnded(object sender, Microsoft.Win32.SessionEndedEventArgs e)
        {
            // do whatever needed and exit application ..
            RegisterHotKey(false);
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            notifyIcon1 = null;
            
    
            if (!mainWindow.dBSaved) mainWindow.SaveDb(Form1.settings.dBPath);
            if (mainWindow.index != null) mainWindow.SaveIndex(Form1.settings.indexPath);
            Microsoft.Win32.SystemEvents.SessionEnded -= new Microsoft.Win32.SessionEndedEventHandler(SystemEvents_SessionEnded);
    
            if (mainWindow != null)
            {
                mainWindow.Dispose();
                mainWindow = null;
            }
            Application.Exit();
        }
