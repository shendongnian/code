    //    Do something like that maybe
    public static string getSeparator()
            {
                string output = string.Empty;
                try
                {
                    RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("International");
                    output = reg.GetValue(EnumClass.String.sList.ToString(), output).ToString();
    
                    reg.Dispose();
                }`enter code here`
                catch (Exception ie)
                {
                    // catch error
                }
                return output;
            }
