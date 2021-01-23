        public static class PrinterHelper
        {
            public class PrinterSettings
            {
                public string Name { get; set; }
                public string ServerName { get; set; }
                public string DeviceId { get; set; }
                public string ShareName { get; set; }
                public string Comment { get; set; }
                public bool Default { get; set; }
            }
    
    
     
            public static void SendFileToPrinter(string filePathAndName, string printerName)
            {
                FileInfo file = new FileInfo(filePathAndName);
                file.CopyTo(printerName);
            }
    
            /// <summary>
            /// Gets all printers that have drivers installed on the calling machine.
            /// </summary>
            /// <returns></returns>
            public static List<PrinterSettings> GetAllPrinters()
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Printer");
                ManagementObjectSearcher mos = new ManagementObjectSearcher(query);
                List<PrinterSettings> printers = new List<PrinterSettings>();
    
                foreach (ManagementObject mo in mos.Get())
                {
                    PrinterSettings printer = new PrinterSettings();
                    foreach (PropertyData property in mo.Properties)
                    {
                        if (property.Name == "Name")
                            printer.Name = property.Value == null ? "" : property.Value.ToString();
    
                        if (property.Name == "ServerName")
                            printer.ServerName = property.Value == null ? "" : property.Value.ToString();
    
                        if (property.Name == "DeviceId")
                            printer.DeviceId = property.Value == null ? "" : property.Value.ToString();
    
                        if (property.Name == "ShareName")
                            printer.ShareName = property.Value == null ? "" : property.Value.ToString();
    
                        if (property.Name == "Comment")
                            printer.Comment = property.Value == null ? "" : property.Value.ToString();
    
                        if (property.Name == "Default")
                            printer.Default = (bool)property.Value;
                    }
                    printers.Add(printer);
                }
    
                return printers;
            }      
    }
