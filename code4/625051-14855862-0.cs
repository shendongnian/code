       namespace ConsoleApplication1
       {
        class Program
        {
        static void Main(string[] args)
        {
            string[] clsids = {
                              "{538793D5-659C-4639-A56C-A179AD87ED44}",
                                  /*Cisco Secure Desktop*/
                              "{705EC6D4-B138-4079-A307-EF13E4889A82}",
                              "{F8FC1530-0608-11DF-2008-0800200C9A66}",
                                  /*Cisco Hostscan*/
                              "{F8FC1530-0608-11DF-2008-0800200C9A66}",
                              "{E34F52FE-7769-46CE-8F8B-5E8ABAD2E9FC}",
                                 /*Cisco AnyConnect Secure Mobility Client*/
                              "{55963676-2F5E-4BAF-AC28-CF26AA587566}",
                              "{CC679CB8-DC4B-458B-B817-D447B3B6AC31}"
                              };
            string[] keys = {  @"Wow6432Node\CLSID",
                                    @"Software\Microsoft\Windows\CurrentVersion\Ext\Settings",
                                    @"Software\Microsoft\Windows\CurrentVersion\Ext\Stats",
                                    @"SOFTWARE\Classes\Wow6432Node\CLSID",
                                    @"SOFTWARE\Wow6432Node\Classes\CLSID",
                                    @"Wow6432Node\Microsoft\Code Store Database\Distribution Units",
                                    @"Wow6432Node\Microsoft\Internet Explorer\ActiveX Compatibility",
                                    @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\ModuleUsage"
    };
            /*Classes root hive*/
            
            for (int i = 0; i<=7; i++ )
            {
            foreach (var regkey in keys)
            {
                try
                {
                            
               using (RegistryKey mykey = Registry.ClassesRoot.OpenSubKey(regkey, true))
                        if (mykey != null)
                        {
                            Console.WriteLine(mykey + @"\"+clsids[i]);
                            mykey.DeleteSubKeyTree(clsids[i]);
                                
                        }
                        
                        else
                        {
                            Console.WriteLine("key does not exist");
                        }
                        
                    /*try end*/
                }
                catch
                {
                    continue;
                }
                
            }
            }
            
            /*Current user hive*/
            
            for (int i = 0; i <= 7; i++)
            {
                foreach (var regkey in keys)
                {
                    try
                    {
                 using (RegistryKey mykey = Registry.CurrentUser.OpenSubKey(regkey, true))
                            if (mykey != null)
                            {
                                Console.WriteLine(mykey + @"\" + clsids[i]);
                                mykey.DeleteSubKeyTree(clsids[i]);
                            }
                            else
                            {
                                Console.WriteLine("key does not exist");
                            }
                        /*try end*/
                    }
                    catch
                    {
                        continue;
                    }
                }
                }
            
            /*Local Machine hive*/
            for (int i = 0; i <= 7; i++)
            {
                foreach (var regkey in keys)
                {
                    try
                    {
                using (RegistryKey mykey = Registry.LocalMachine.OpenSubKey(regkey, true))
                            if (mykey != null)
                            {
                                Console.WriteLine(mykey + @"\" + clsids[i]);
                                mykey.DeleteSubKeyTree(clsids[i]);
                            }
                            else
                            {
                                Console.WriteLine("key does not exist");
                            }
                        /*try end*/
                    }
                    catch
                    {
                        continue;
                    }
                }
                }
            Console.WriteLine("Cleanup finished. Press any key to exit");
            Console.ReadLine();
        }
        }
        }
