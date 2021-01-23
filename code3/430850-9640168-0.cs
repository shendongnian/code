    void CheckForShortcut()
    {
        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
     
        if (ad.IsFirstRun)
        {
            Assembly code = Assembly.GetExecutingAssembly();
     
            string company = string.Empty;
            string description = string.Empty;
     
            if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
            {
                AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                    typeof(AssemblyCompanyAttribute));
                company = ascompany.Company;
            }
     
            if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            {
                AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                    typeof(AssemblyDescriptionAttribute));
                description = asdescription.Description;
            }
     
            if (company != string.Empty && description != string.Empty)
            {
                string desktopPath = string.Empty;
                desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "\\", description, ".appref-ms");
     
                string shortcutName = string.Empty;
                shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                    "\\", company, "\\", description, ".appref-ms");
     
                System.IO.File.Copy(shortcutName, desktopPath, true);
            }
     
        }
    }
