    public static bool IsDesignTime()
    {
      return System.ComponentModel.LicenseManager.UsageMode ==
             System.ComponentModel.LicenseUsageMode.Designtime;
    }
    
    public static bool IsRunTime()
    {
      return System.ComponentModel.LicenseManager.UsageMode ==
             System.ComponentModel.LicenseUsageMode.Runtime;
    }
