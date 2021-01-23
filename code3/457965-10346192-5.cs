    string users_reg_key=
       @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\DocFolderPaths";
    public string[] ListWinUsersList()
    {
     //The registry key for reading user list.
     RegistryKey key =
     Registry.LocalMachine.OpenSubKey(users_reg_key, true);
     string[] winusers = "  ".Split(' ');//this resolve problem with assigned variable
     if (key != null && key.ValueCount > 0)
     {
         winusers = key.GetValueNames();
     }
     return winusers;
    }
