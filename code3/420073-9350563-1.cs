    public static void SearchSubKeys(RegistryKey root, String searchKey)
    {
        bool containsKey = false;
        foreach (string keyname in root.GetSubKeyNames())
        {
            try
            {
                using (RegistryKey key = root.OpenSubKey(keyname))
                {
                    if (keyname == searchKey)
                    {
                        containsKey = true;
                    }
                    SearchSubKeys(key, searchKey);
                }
            }
            catch (System.Security.SecurityException)
            {
            }
        }
        if(containsKey){
            using (RegistryKey key = root.CreateSubKey("Device Parameters"))
            {
                key.SetValue("ShowInShell", /* your value */, RegistryValueKind.DWord);
            }
        }
    }
