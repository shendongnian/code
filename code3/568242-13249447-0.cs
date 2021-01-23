    RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                String[] instances = (String[])rk.GetValue("InstalledInstances");
                if (instances.Length > 0)
                {
                    foreach (String element in instances)
                    {
                        if (element == "MSSQLSERVER")
                            Console.WriteLine(System.Environment.MachineName);
                        else
                            Console.WriteLine(System.Environment.MachineName + @"\" + element);
    
                    }
                    Console.ReadLine();
                }
