    RegistryKey OurKey = Registry.LocalMachine;
    OurKey = OurKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", true);
    
    foreach (string Keyname in OurKey.GetSubKeyNames())
    {
        RegistryKey key = OurKey.OpenSubKey(Keyname);
    
        MessageBox.Show(key.GetValue("ProfileImagePath").ToString());
    } 
