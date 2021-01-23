            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_NetworkAdapter"))
            {
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject obj in results)
                {
                    System.Console.WriteLine("Found adapter {0} :", obj["Caption"]);
                    System.Console.WriteLine("Disabling adapter ...");
                    object[] param = new object[0];
                    obj.InvokeMethod("Disable",param);
                    System.Console.WriteLine("Done.");
                }
                Console.ReadLine();
            }
