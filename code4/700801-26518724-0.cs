    public static class RegistrySettings
    {
    private static RegistryKey baseRegistryKey = Registry.CurrentUser;
    private static string _SubKey = string.Empty;
    public static string SubRoot 
    {
        set
        { _SubKey = value; }
    }
    public static string Read(string KeyName, string DefaultValue)
    {
        // Opening the registry key 
        RegistryKey rk = baseRegistryKey;
        // Open a subKey as read-only 
        RegistryKey sk1 = rk.OpenSubKey(_SubKey);
        // If the RegistrySubKey doesn't exist return default value
        if (sk1 == null)
        {
            return DefaultValue;
        }
        else
        {
            try
            {
                // If the RegistryKey exists I get its value 
                // or null is returned. 
                return (string)sk1.GetValue(KeyName);
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Reading registry {0}", KeyName.ToUpper()));
                return null;
            }
        }
    }
    public static bool Write(string KeyName, object Value)
    {
        try
        {
            // Setting
            RegistryKey rk = baseRegistryKey;
            // I have to use CreateSubKey 
            // (create or open it if already exits), 
            // 'cause OpenSubKey open a subKey as read-only
            RegistryKey sk1 = rk.CreateSubKey(_SubKey);
            // Save the value
            sk1.SetValue(KeyName, Value);
            return true;
        }
        catch (Exception e)
        {
            ShowErrorMessage(e, String.Format("Writing registry {0}", KeyName.ToUpper()));
            return false;
        }
    }
    private static void ShowErrorMessage(Exception e, string Title)
    {
        if (ShowError == true)
            MessageBox.Show(e.Message,
                    Title
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
    }
    }
