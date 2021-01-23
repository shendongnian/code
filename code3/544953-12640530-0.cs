    using System.Management;
    public bool IsPrinterReady(string printerName)
            {
            bool bprinterOnline = false;       
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();
            // Select Printers from WMI Object Collections
            ManagementObjectSearcher printerSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printer in printerSearcher.Get())
            {
                
                if (string.IsNullOrEmpty(printer["Name"].ToString()))
                {
                    if (printer["Name"].ToString().ToLower().Equals(printerName.ToLower()))
                    {
                        switch (printer["WorkOffline"].ToString().ToLower())
                        {
                            case "true":
                                bprinterOnline= true;
                                break;
                            case "false": 
                                bprinterOnline= false;
                                break;
                            default:
                                bprinterOnline= false;
                                break;
                        }
                        break;                     
                    }
                }
            }
            return bprinterOnline;
        }
