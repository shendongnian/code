    using (FileStream fs = new FileStream("c:\\linksLog.txt", FileMode.Append, FileAccess.Write), StreamWriter sw = new StreamWriter(fs))
    {
        for (int i = 0; i < linksList.Count; i++)
        {
            try
            {
                System.Diagnostics.Process.Start(browserType, linksList[i]);                        
            }
            catch (Exception)
            {
        
            }
        
            Thread.Sleep((int)delayTime);
        
            if (!cbNewtab.Checked)
            {
                try
                {
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName == getProcesses)
                        {
                            process.Kill();
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
    }
