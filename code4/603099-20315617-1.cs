    private void buttonGetMachineGuid_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        string x64Result = string.Empty;
        string x86Result = string.Empty;
        RegistryKey keyBaseX64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        RegistryKey keyBaseX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        RegistryKey keyX64 = keyBaseX64.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", RegistryKeyPermissionCheck.ReadSubTree);
        RegistryKey keyX86 = keyBaseX86.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", RegistryKeyPermissionCheck.ReadSubTree);
        object resultObjX64 = keyX64.GetValue("MachineGuid", (object)"default");
        object resultObjX86 = keyX86.GetValue("MachineGuid", (object)"default");
        keyX64.Close();
        keyX86.Close();
        keyBaseX64.Close();
        keyBaseX86.Close();
        keyX64.Dispose();
        keyX86.Dispose();
        keyBaseX64.Dispose();
        keyBaseX86.Dispose();
        keyX64 = null;
        keyX86 = null;
        keyBaseX64 = null;
        keyBaseX86 = null;
        if(resultObjX64 != null && resultObjX64.ToString() != "default")
        {
          MessageBox.Show(resultObjX64.ToString());
        }
        if(resultObjX86 != null && resultObjX86.ToString() != "default")
        {
          MessageBox.Show(resultObjX86.ToString());
        }
      }
      catch(Exception)
      {
      }
    }
