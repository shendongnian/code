    //Renames the printer
    public static void RenamePrinter(string sPrinterName, string newName)
    {
        ManagementScope oManagementScope = new ManagementScope(ManagementPath.DefaultPath);
        oManagementScope.Connect();
        SelectQuery oSelectQuery = new SelectQuery();
        oSelectQuery.QueryString = @"SELECT * FROM Win32_Printer WHERE Name = '" + sPrinterName.Replace("\\", "\\\\") + "'";
        ManagementObjectSearcher oObjectSearcher =
            new ManagementObjectSearcher(oManagementScope, oSelectQuery);
        ManagementObjectCollection oObjectCollection = oObjectSearcher.Get();
        if (oObjectCollection.Count == 0)
            return;
        foreach (ManagementObject oItem in oObjectCollection)
        {
            int state = (int)oItem.InvokeMethod("RenamePrinter", new object[] { newName });
            switch (state)
            {
                case 0:
                    //Success do noting else
                    return;
                case 1:
                    throw new AccessViolationException("Access Denied");
                case 1801:
                    throw new ArgumentException("Invalid Printer Name");
                default:
                    break;
            }
        }
    }
