    public static bool IsSoftwareInstalled(string softwareName, string remoteMachine = null, StringComparison strComparison = StringComparison.Ordinal)
    {
        string uninstallRegKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        RegistryView[] enumValues = (RegistryView[])Enum.GetValues(typeof(RegistryView));
        //Starts from 1, because first one is Default, so we dont need it...
        for (int i = 1; i < enumValues.Length; i++)
        {
            //This one key is all what we need, because RegView will do the rest for us
            using (RegistryKey regKey = (string.IsNullOrWhiteSpace(remoteMachine))
                        ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, enumValues[i]).OpenSubKey(uninstallRegKey)
                        : RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteMachine, enumValues[i]).OpenSubKey(uninstallRegKey))
            {
                  if (SearchSubKeysForValue(regKey, "DisplayName", softwareName, strComparison).Result)
                  { return true; }
            }
        }
        return false;
    }
