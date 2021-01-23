    private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Process[] myProcess = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName); 
                foreach (Process process in myProcess) 
                {
                    if (process.Id == Process.GetCurrentProcess().Id)
                        continue;
                    else
                        process.Kill();
                } 
            }
