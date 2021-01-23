    private void Hack_Fixx64RegistryForGettingLocalAccounts(string ServerName)
    {
        RegistryKey remoteKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ServerName, RegistryView.Registry64);
        if(remoteKey != null)
        {
            //Get keys stored on 64 bit location
            RegistryKey x64regkey = remoteKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string regOwner = Convert.ToString(x64regkey.GetValue("RegisteredOwner", ""));
            string regOrganization = Convert.ToString(x64regkey.GetValue("RegisteredOrganization", ""));
            //Add missing keys on 64 bit OS in correct location for 32 bit registry area. The Wow6432Node is for 32-bit apps that run on 64-bit window versions.
            remoteKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ServerName, RegistryView.Registry32);
            if(remoteKey != null)
            {
                RegistryKey x86regkey = remoteKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true);
                x86regkey.SetValue("RegisteredOwner", regOwner);
                x86regkey.SetValue("RegisteredOrganization", regOrganization);
            }
        }
    }
