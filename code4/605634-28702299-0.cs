      using Microsoft.Win32;
    
    
    
        public partial class Form1 : Form
                {
        
              
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                public Form1()
                {
                    reg.SetValue("AutoRun", Application.ExecutablePath.ToString());
                    InitializeComponent();
                }
        }
