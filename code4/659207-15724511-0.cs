    ManagementClass managClass = new ManagementClass("win32_processor");
    ManagementObjectCollection managCollec = managClass.GetInstances();
    foreach (ManagementObject managObj in managCollec)
    {
        cpuInfo = managObj.Properties["processorID"].Value.ToString();
        break;
    }
