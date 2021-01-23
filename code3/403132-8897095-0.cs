            var process = Process.Start("notepad.exe");
            var process2 = Process.GetProcessById(process.Id);
            while (!process2.HasExited)
            {
                Thread.Sleep(1000);
                try
                {
                    process2 = Process.GetProcessById(process.Id);
                }
                catch (ArgumentException)
                {
                    break;
                }
                
            }
            MessageBox.Show("done");
