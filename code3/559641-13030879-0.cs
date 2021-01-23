    using Microsoft.Win32;
    ...
     
    RegistryKey masterKey = Registry.LocalMachine.CreateSubKey(
                "SOFTWARE\\Test\\Preferences");
    if (masterKey == null)
    {
        Console.WriteLine ("Null Masterkey!");
    }
    else
    {
        Console.WriteLine ("MyKey = {0}", masterKey.GetValue ("MyKey"));
    }
    masterKey.Close();
