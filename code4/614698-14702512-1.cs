           private void Application_Startup(object sender, StartupEventArgs e)
           {
            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p=> 
                             p.ProcessName == proc.ProcessName).Count();
            if (count > 1)
            {
                MessageBox.Show("Already an instance is running...");
                App.Current.Shutdown(); 
            }
          }
  
