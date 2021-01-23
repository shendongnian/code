    public void ClearBrowserPrintHeaderAndFooter()
    {
    	string path = "Software\\\\Microsoft\\\\Internet Explorer\\\\PageSetup";
    	Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);
    	if (key == null) {
    		key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path, true);
    	}
    	key.SetValue("header", "");
    	key.SetValue("footer", "");
    	key.Close();
    }
