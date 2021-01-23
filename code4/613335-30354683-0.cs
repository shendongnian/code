    public bool IsInstalledReportViewer()
    {
        try
        {
            RegistryKey registryBase = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty);
            if (registryBase != null)
            {
                // check the two possible reportviewer v10 registry keys
                return registryBase.OpenSubKey(@"Software\Microsoft\ReportViewer\v2.0.50727") != null
                    || registryBase.OpenSubKey(@"Software\Wow6432Node\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\ReportViewer v10") != null
                    || registryBase.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\ReportViewer\v10.0") != null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // put proper exception handling here
        }
        return false;
    }
