    using System;
    using Microsoft.Win32;
    
    namespace CheckSecureBoot
    {
        class Program
        {
            static int Main()
            {
                int rc = 0;
                string key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecureBoot\State";
                string subkey = @"UEFISecureBootEnabled";
                try
                {
                    object value = Registry.GetValue(key, subkey, rc);
                    if (value != null)
                        rc = (int)value;
                }
                catch { }
                Console.WriteLine($@"{subkey} is {(rc >= 1 ? "On" : "Off")} ({rc.ToString()})");
                return rc;
            }
        }
    }
