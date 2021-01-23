    public static void CopyTo(this RegistryKey src, RegistryKey dst)
    {
        // copy the values
        foreach (var name in src.GetValueNames())
        {
            dst.SetValue(name, src.GetValue(name), src.GetValueKind(name));
        }
        // copy the subkeys
        foreach (var name in src.GetSubKeyNames())
        {
            using (var srcSubKey = src.OpenSubKey(name, false))
            {
                var dstSubKey = dst.CreateSubKey(name);
                srcSubKey.CopyTo(dstSubKey);
            }
        }
    }
