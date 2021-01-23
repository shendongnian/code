        public static bool IsSoftwareInstalled(string softwareName, string remoteMachine = null, StringComparison strComparison = StringComparison.Ordinal)
        {
            string uninstallRegKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryView[] enumValues = (RegistryView[])Enum.GetValues(typeof(RegistryView));
            //Starts from 1, because first one is Default, so we dont need it...
            for (int i = 1; i < enumValues.Length; i++)
            {
                //This one key is all what we need, because RegView will do the rest for us
                using (RegistryKey key = (string.IsNullOrWhiteSpace(remoteMachine))
                    ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, enumValues[i]).OpenSubKey(uninstallRegKey)
                    : RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteMachine, enumValues[i]).OpenSubKey(uninstallRegKey))
                {
                    if (key != null)
                    {
                        if (key.GetSubKeyNames()
                            .Select(keyName => key.OpenSubKey(keyName))
                            .Select(subKey => subKey.GetValue("DisplayName") as string)
                            //SomeTimes we really need the case sensitive/insensitive option...
                            .Any(displayName => displayName != null && displayName.IndexOf(softwareName, strComparison) >= 0))
                        { return true; }
                    }
                }
            }
            return false;
        }
