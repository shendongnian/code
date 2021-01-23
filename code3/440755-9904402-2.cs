     using (var searcher = new ManagementObjectSearcher("SELECT totalphysicalmemory FROM Win32_ComputerSystem"))
            {
                using (var wmiData = searcher.Get())
                {
                    foreach (var mo in wmiData)
                    {
                        totalMemory = long.Parse(mo["totalphysicalmemory"].ToString());
                    }
                }
            }
