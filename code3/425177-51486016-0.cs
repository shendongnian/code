    /// <summary>
    /// Gets the specified setting name.
    /// </summary>
    /// <param name="settingName">Name of the setting.</param>
    /// <returns>Returns Setting if the read was successful otherwise, "undefined".</returns>
    public static string get(string settingName)
    {
        RegistryKey key;
        if (Environment.Is64BitOperatingSystem)
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\MyCompany\MyProductName", false);
        else
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\MyCompany\MyProductName", false);
        try
        {
            String value = (String)key.GetValue(settingName);
            return value;
        }
        catch
        {
            // Null is not returned as in this case, it is a valid value.
            return "undefined";
        }
        finally
        {
            key.Close();
        }
    }
