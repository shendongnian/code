    public string GetCustomUI(string ribbonID)
    {
       if (System.Environment.GetEnvironmentVariable("MyVar", EnvironmentVariableTarget.Process) == "1")
       {
            return GetResourceText("ExcelAddIn.ExcelRibbon.xml");
       }
       else
       {
            return GetResourceText("ExcelAddIn.BasicRibbon.xml");
       }
    }
