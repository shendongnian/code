            //Get system RAM
            private double GetSystemRam()
            {
                var searcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
                double total_Ram_Bytes = 0;
                foreach (ManagementObject Mobject in searcher.Get())
                {
                    total_Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                    Console.WriteLine("RAM Size in Giga Bytes: {0}", total_Ram_Bytes / 1073741824);
                    
                }
                return total_Ram_Bytes;
            }
    
            //Get system processor speed
            private int GetprocessorSpeed()
            {
                var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
                int processorSpeed = 0;
                foreach (var item in searcher.Get())
                {
                    processorSpeed = Convert.ToInt32(item["MaxClockSpeed"]);
                    Console.WriteLine("Processor Speed is(GHz):" + processorSpeed);
                }
                return processorSpeed;
            }
    
            //Get system maximum resolution
            private void GetMaxResolution()
            {
                using (var searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM CIM_VideoControllerResolution"))
                {
                    var results = searcher.Get();
                    UInt32 maxHResolution = 0;
                    UInt32 maxVResolution = 0;
    
                    foreach (var item in results)
                    {
                        if ((UInt32)item["HorizontalResolution"] > maxHResolution)
                            maxHResolution = (UInt32)item["HorizontalResolution"];
    
                        if ((UInt32)item["VerticalResolution"] > maxVResolution)
                            maxVResolution = (UInt32)item["VerticalResolution"];
                    }
    
                    Console.WriteLine("Max Supported Resolution " + maxHResolution + "x" + maxVResolution);
                }
            }
            //Check for availability of keyboard 
            private bool IsKeyboardAvailable()
            {
                bool isKeyboardAvailable = false;
                var searcher = new ManagementObjectSearcher("select * from Win32_Keyboard");
    
                List<string> keyBoardName = new List<string>();
                foreach (var item in searcher.Get())
                {
                    keyBoardName.Add(Convert.ToString(item["Name"]));
                    Console.WriteLine("KeyBoard name is :" + item["Name"]);
                    isKeyboardAvailable = true;
                }
                return isKeyboardAvailable;
            }
    
            //Check for availability of printer
            private bool IsPrinterAvailable()
            {
                bool isPrinterAvailable = false;
                var searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
                List<string> printerName = new List<string>();
                foreach (var item in searcher.Get())
                {
                    printerName.Add(item["Name"].ToString().ToLower());
                    Console.WriteLine("Printer name is :" + item["Name"]);
                    isPrinterAvailable = true;
                }
                return isPrinterAvailable;
            }
    
            //Check for availability of mouse
            private bool IsMouseAvailable()
            {
                bool isMouseAvailable = false;
                var searcher = new ManagementObjectSearcher("Select * from Win32_PointingDevice");
                List<string> mouseType = new List<string>();
                foreach (var item in searcher.Get())
                {
                    mouseType.Add(item["Name"].ToString().ToLower());
                    Console.WriteLine("Mouse type is :" + item["Name"]);
                    isMouseAvailable = true;
                }
                return isMouseAvailable;
            }
