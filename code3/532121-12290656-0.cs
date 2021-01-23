            try
            {
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("WinWord");
                foreach (var myproc in procs)
                    myproc.Kill();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
