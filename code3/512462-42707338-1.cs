        private bool IsPrinterOk(string name,int checkTimeInMillisec)
        {
            System.Collections.IList value = null;
            do
            {
                //checkTimeInMillisec should be between 2000 and 5000
                System.Threading.Thread.Sleep(checkTimeInMillisec);
                // or use Timer with Threading.Monitor instead of thread sleep
                using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_PrintJob WHERE Name like '%" + name + "%'"))
                {
                    value = null;
                    if (searcher.Get().Count == 0) // Number of pending document.
                        return true; // return because we haven't got any pending document.
                    else
                    {
                        foreach (System.Management.ManagementObject printer in searcher.Get())
                        {
                            value = printer.Properties.Cast<System.Management.PropertyData>().Where(p => p.Name.Equals("Status")).Select(p => p.Value).ToList();
                            break; 
                        }
                    }
                }
           }
           while (value.Contains("Printing") || value.Contains("UNKNOWN") || value.Contains("OK"));
           return value.Contains("Error") ? false : true;    
        }
