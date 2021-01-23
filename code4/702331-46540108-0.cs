    public static string GetWindowsUserAccountName()
    {
	string userName = string.Empty;
    ManagementScope ms = new ManagementScope("\\\\.\\root\\cimv2");
    ObjectQuery query = new ObjectQuery("select * from win32_computersystem");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, query);
                
    foreach (ManagementObject mo in searcher?.Get())
    {
    userName = mo["username"]?.ToString();
    }
    userName = userName?.Substring(userName.IndexOf(@"\") + 1);
    return userName;
	}
