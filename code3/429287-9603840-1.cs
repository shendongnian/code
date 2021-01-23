    public static string ReadDefaultValue(string regKey)
    {
        using (var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regKey, false))
        {
            if (key != null)
            {
                return key.GetValue("") as string;
            }
        }
        return null;
    }
    public static string GetDescription(string ext)
    {
        if (ext.StartsWith(".") && ext.Length > 1) ext = ext.Substring(1);
        var retVal = ReadDefaultValue(ext + "file");
        if (!String.IsNullOrEmpty(retVal)) return retVal;
        
        using (var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + ext, false))
        {
            if (key == null) return "";
            using (var subkey = key.OpenSubKey("OpenWithProgids"))
            {
                if (subkey == null) return "";
                var names = subkey.GetValueNames();
                if (names == null || names.Length == 0) return "";
                foreach (var name in names)
                {
                    retVal = ReadDefaultValue(name);
                    if (!String.IsNullOrEmpty(retVal)) return retVal;
                }
            }
        }
        return "";
    }
