            // Enumerate the Win32_Processor class
            EnumerationOptions opt = new EnumerationOptions();
            ManagementClass c = new ManagementClass("Win32_Processor");
            foreach (ManagementObject o in c.GetInstances(opt))
            {
                foreach (var item in o.Properties)
                {
                    Console.WriteLine(item.Name + " " + item.Value);
                }
            }
