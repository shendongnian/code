    private InstalledPrinter PreferredPrinter { get; set; }
    private InstalledPrinter DefaultPrinter { get; set; }
        private void SetDefaultAndPreferredPrinters()
        {
            if (UserSettings[SETTING_PREFERRED_PRINTER] == null)
            {
                UserSettings[SETTING_PREFERRED_PRINTER] = string.Empty;
            }
            _preferredPrinterName = ((string)UserSettings[SETTING_PREFERRED_PRINTER]).Trim();
            List<InstalledPrinter> installedPrinters = InstalledPrinter.GetList();
            DefaultPrinter = null;
            PreferredPrinter = null;
            foreach (InstalledPrinter installedPrinter in installedPrinters)
            {
                if (installedPrinter.IsDefault)
                {
                    DefaultPrinter = installedPrinter;
                }
                if (installedPrinter.Name.Equals(_preferredPrinterName, StringComparison.InvariantCultureIgnoreCase))
                {
                    PreferredPrinter = installedPrinter;
                }
            }
        }
    public static List<InstalledPrinter> GetList()
    {
        PrinterSettings ps = new PrinterSettings();
			string sDefault = ps.PrinterName;
        string query = "Select * From Win32_Printer";
 
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
 
        ManagementObjectCollection results = searcher.Get();
 
        List<InstalledPrinter> list = new List<InstalledPrinter>(results.Count);
 
        foreach (ManagementObject printManagementObject in results)
        {
            InstalledPrinter entry = new InstalledPrinter();
            foreach (PropertyInfo propertyInfo in typeof(InstalledPrinter).GetProperties()) {
                object[] oparams = {1};
                if (propertyInfo.Name != "IsDefault") {//The IsDefault property is worked out logically, the rest of the properties map identically to the columns of the WMI query results.
                    try {
                        oparams[0] = ConvertValue(
                            printManagementObject[propertyInfo.Name], propertyInfo.PropertyType);
                        propertyInfo.GetSetMethod().Invoke(
                            entry,
                            oparams);
                    }catch(Exception e) {
                        _s_logger.Error(string.Format("Failed to enumerate printer property Name:{0}, Type:{1}", propertyInfo.Name, propertyInfo.PropertyType));
                    }
                }
            }
            _s_logger.Info(string.Format("Finished enumerating properties of printer: {0}", entry.Name == null ? "<Null>" : entry.Name));
            if (sDefault.Equals(entry.Name, StringComparison.CurrentCultureIgnoreCase)) {
                entry.IsDefault = true;
            }
            list.Add(entry);
        }
        return list;
    }
