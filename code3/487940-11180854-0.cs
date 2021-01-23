    private static void ModifyExcelSecuritySettings()
    {
        // Make sure we have programmatic access to the project to run macros
        using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\14.0\Excel\Security", true))
        {
            if (key != null)
            {
                if ((int)key.GetValue("AccessVBOM", 0) != 1)
                {
                    key.SetValue("AccessVBOM", 1);
                }
                key.Close();
            }
        }
    }
