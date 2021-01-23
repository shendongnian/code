    List<string> installedRuntimes = new List<string>();
    Regex rxVersion = new Regex(@"^[v](\d{1,5})([\.](\d{1,5})){0,3}$");
    Regex rxVersionPart = new Regex(@"^\d{1,5}$");            
    try
    {
        string installPath = Convert.ToString(Registry.GetKey("HKEY_LOCAL_MACHINE/SOFTWARE/Microsoft/.NETFramework").GetValue("InstallRoot"));
        string[] shortVersions = Registry.GetKey("HKEY_LOCAL_MACHINE/SOFTWARE/Microsoft/.NETFramework/Policy", false).GetSubKeyNames();
        foreach (string shortVersion in shortVersions)
            if (rxVersion.IsMatch(shortVersion))
            {
                string[] versionExtensions = Registry.GetKey("HKEY_LOCAL_MACHINE/SOFTWARE/Microsoft/.NETFramework/Policy/" + shortVersion, false).GetValueNames();
                foreach (string versionExtension in versionExtensions)
                    if (rxVersionPart.IsMatch(versionExtension))
                    {
                        string fullVersion = shortVersion + "." + versionExtension;
                        if (rxVersion.IsMatch(fullVersion))
                        {
                            string clrPath = installPath + fullVersion + "\\mscorlib.dll";
                            if (File.Exists(clrPath) && FileVersionInfo.GetVersionInfo(clrPath).FileVersion.StartsWith(fullVersion.Substring(1))) installedRuntimes.Add(fullVersion);
                        }
                    }
            }
    }
    catch { } // No CLR installed.
