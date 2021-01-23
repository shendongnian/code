     Process process = Process.GetCurrentProcess();
     Process [] duplicateProcess = Process.GetProcessesByName(process.ProcessName).ToArray();
     if (duplicateProcess.Length > 1)
     { 
            if (MessageBox.Show("Duplicate Found. Do you want to kill duplicate process", "Duplicate Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Process p in duplicateProcess)
                {
                    int res = DateTime.Compare(p.StartTime, process.StartTime);
                    if (res < 0)
                    {
                        // P process opened first
                        p.Kill();
                    }
                    else if ( res > 0 )
                    {
                        // process Opened first
                        process.Kill();
                    }
                }
            }
        }
