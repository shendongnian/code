    public static String GetCPUId()
    {
        String processorID = "";
    
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(
            "Select * FROM WIN32_Processor");
    
        ManagementObjectCollection mObject = searcher.Get();
    
        foreach (ManagementObject obj in mObject)
        {
            processorID = obj["ProcessorId"].ToString();
        }
    
        return processorID;
    }
