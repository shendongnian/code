    public Form1()
            {
                InitializeComponent();
                notifyIcon1.ContextMenuStrip = contextMenuStrip1;
    
                //Make the call to add the registry key here (plus Check or Uncheck the menu)
                menu_startup_Click(null,null); 
     
                this.menu_startup.Click += menu_startup_Click;                
            }    
     private void menu_startup_Click(object sender, EventArgs e)
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                //Check or Uncheck the menu
                this.menu_startup.Checked = (rkApp.GetValue(this.regKey) == null)
                if (rkApp.GetValue(this.regKey) == null)
                {
                    rkApp.SetValue(this.regKey, Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue(this.regKey, false);
                }               
            }
