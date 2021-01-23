    RegistryKey OurKey = Registry.LocalMachine;
    OurKey = OurKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", true);
    
    foreach (string Keyname in OurKey.GetSubKeyNames())
    {
        RegistryKey key = OurKey.OpenSubKey(Keyname);
    
        MessageBox.Show(key.GetValue("KEY_NAME").ToString()); // Replace KEY_NAME with what you're looking for
    } 
