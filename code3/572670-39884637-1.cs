    using Microsoft.Win32;
    //...
    private void DNSAutoOrStatic(string NetworkAdapterGUID)
            {
                string path = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\\" + NetworkAdapterGUID;
                string ns = (string)Registry.GetValue(path, "NameServer", null);
                if (String.IsNullOrEmpty(ns))
                {
                    Console.WriteLine("Dynamic DNS");
                }
                else
                {
                    Console.WriteLine("Static DNS: " + ns);
                }
            }
