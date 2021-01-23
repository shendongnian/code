    using Microsoft.Win32;
    ...
    /// <summary>
    /// This method returns a list of registry values from a given key in .reg format.
    /// </summary>
    /// <param name="key">Registry key from which to obtain values.</param>
    /// <returns>A CR-separated list of all the registry values for a given key.</returns>
    private static string ParseChildValues(RegistryKey key)
    {
        if (key.IsNull())
            return string.Empty;
        StringBuilder sb = new StringBuilder();
        foreach(string val in key.GetValueNames())
        {
            sb.AppendFormat("{0}=\"{1}\"", string.IsNullOrEmpty(val) ? "@" : val, key.GetValue(val));
            sb.AppendLine();
        }
        return sb.ToString();
    }
    /// <summary>
    /// Parses the SubKeys of a given RegistryKey.
    /// </summary>
    /// <param name="key">A registry key</param>
    /// <returns>Lots of important data!</returns>
    private static string ParseKey(RegistryKey key)
    {
        if (key.IsNull())
            return string.Empty;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendFormat("[{0}]", key.Name);
        sb.AppendLine();
        sb.Append(ParseChildValues(key));
        foreach (var subKey in key.GetSubKeyNames())
        {
            sb.Append(ParseKey(key.OpenSubKey(subKey)));
        }
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        // Dump the contents of HKEY_CLASSES_ROOT\*
        Console.WriteLine("Getting the contents of HKCR\\* on the local machine");
        RegistryKey localHKCR = Registry.ClassesRoot.OpenSubKey("*", RegistryKeyPermissionCheck.ReadSubTree);
        Console.WriteLine(ParseKey(localHKCR));
        // Dump the contents of HKEY_CLASSES_ROOT\* on a remote machine.
        Console.WriteLine();
        Console.WriteLine("Getting the contents of HKCR\\* via OpenRemoteBaseKey");
        RegistryKey remoteHKCR = RegistryKey.OpenRemoteBaseKey(RegistryHive.ClassesRoot, "MACHINENAME");
        Console.WriteLine(ParseKey(remoteHKCR.OpenSubKey("*", RegistryKeyPermissionCheck.ReadSubTree)));
    }
