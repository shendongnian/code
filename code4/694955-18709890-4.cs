    private const string CLEARABLE_LIST_DATA = @"Software\Microsoft\Internet Explorer\BrowserEmulation\ClearableListData";
    private const string USERFILTER = "UserFilter";
    private static string[] GetDomains()
    {
        string[] domains;
        using (Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CLEARABLE_LIST_DATA))
        {
            byte[] filter = regkey.GetValue(USERFILTER) as byte[];
            domains = GetDomains(filter);
        }
        return domains;
    }
    /* IT'S DANGER!! */
    // You shouldn't call until it becomes completely obvious that UNKNOWN parameter is meaning.
    private static void AddUserFilter(string domain)
    {
        using (Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(CLEARABLE_LIST_DATA))
        {
            byte[] filter = regkey.GetValue(USERFILTER) as byte[];
            byte[] newReg = GetAddedValue(domain, filter);
            regkey.SetValue(USERFILTER, newReg, Microsoft.Win32.RegistryValueKind.Binary);
        }
    }
    private static void RemoveUserFilter(string domain)
    {
        using (Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CLEARABLE_LIST_DATA))
        {
            byte[] filter = regkey.GetValue(USERFILTER) as byte[];
            byte[] newReg = GetRemovedValue(domain, filter);
            if (GetDomains(newReg).Length == 0)
                regkey.DeleteValue(USERFILTER);
            else
                regkey.SetValue(USERFILTER, newReg, Microsoft.Win32.RegistryValueKind.Binary);
        }
    }
    private static byte[] GetFilter()
    {
        byte[] filter;
        using (Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CLEARABLE_LIST_DATA))
        {
            filter = regkey.GetValue(USERFILTER) as byte[];
        }
        return filter;
    }
    private static string[] GetDomains(byte[] filter)
    {
        List<string> domains = new List<string>();
        
        int length;
        int offset_filter = 24;
        int totalSize = filter.Length;
        while (offset_filter < totalSize)
        {
            length = BitConverter.ToUInt16(filter, offset_filter + 16);
            domains.Add(System.Text.Encoding.Unicode.GetString(filter, 16 + 2 + offset_filter, length * 2));
            offset_filter += 16 + 2 + length * 2;
        }
        return domains.ToArray();
    }
    private static byte[] GetAddedValue(string domain, byte[] filter)
    {
        byte[] SEPARATOR = new byte[] { 0x0C, 0x00, 0x00, 0x00 };
        byte[] CONSTANT = new byte[] { 0x01, 0x00, 0x00, 0x00 };
        byte[] UNKNOWN = BitConverter.GetBytes(DateTime.Now.ToBinary());
        List<byte> newReg = new List<byte>();
        byte[] binDomain = System.Text.Encoding.Unicode.GetBytes(domain);
        newReg.AddRange(filter);
        newReg.AddRange(SEPARATOR);
        /************************************************************************************************/
        newReg.AddRange(UNKNOWN); // IT'S IRRESPONSIBLE!!  Setting 0x00 is preferable to adding DateTime
        /************************************************************************************************/
        newReg.AddRange(CONSTANT);
        newReg.AddRange(BitConverter.GetBytes((UInt16)domain.Length));
        newReg.AddRange(binDomain);
        byte[] newSize = BitConverter.GetBytes((UInt16)(newReg.Count - 12));
        newReg[12] = newSize[0];
        newReg[13] = newSize[1];
        return newReg.ToArray();
    }
    private static byte[] GetRemovedValue(string domain, byte[] filter)
    {
        byte[] newReg;
        int length;
        int offset_filter = 24;
        int offset_newReg = 0;
        int totalSize = filter.Length;
        newReg = new byte[totalSize];
        Array.Copy(filter, 0, newReg, 0, offset_filter);
        offset_newReg += offset_filter;
        while (offset_filter < totalSize)
        {
            length = BitConverter.ToUInt16(filter, offset_filter + 16);
            if (domain != System.Text.Encoding.Unicode.GetString(filter, offset_filter + 16 + 2, length * 2))
            {
                Array.Copy(filter, offset_filter, newReg, offset_newReg, 16 + 2 + length * 2);
                offset_newReg += 16 + 2 + length * 2;
            }
            offset_filter += 16 + 2 + length * 2;
        }
        Array.Resize(ref newReg, offset_newReg);
        byte[] newSize = BitConverter.GetBytes((UInt16)(offset_newReg - 12));
        newReg[12] = newSize[0];
        newReg[13] = newSize[1];
        return newReg;
    }
