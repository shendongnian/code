    RegistryKey r = Registry.LocalMachine;
    r = r.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\{C641C770-FAAC-44ED-9C73-48D1B5E59200}\NDIS&VEN_1924&DEV_0803&SUBSYS_62271924", false);  
    foreach (string s in r.GetSubKeyNames())
    {
        using (RegistryKey subKey = r.OpenSubKey(s))
        {
            Console.WriteLine(subKey.GetValue("FriendlyName"));
        }
    }
    r.Close();
