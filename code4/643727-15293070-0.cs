    public static bool IsRunningInIdeContext
    {
        get {
            if (DesignerProperties.IsInDesignMode)
                return true;
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
