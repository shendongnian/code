    foreach (ManagementObject printer in printerCollection)
    {
        PropertyDataCollection printerProperties = printer.Properties;
        foreach (PropertyData property in printerProperties)
        {
            if (property.Name == "KeepPrintedJobs")
            {
                printerProperties[property.Name].Value = true;
            }
        }
        printer.Put();
    }
