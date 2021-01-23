    public static partial class ExtensionMethods
    {
        public static bool IsInDesignMode(this Control source)
        {
            var result = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            while (result == false && source != null)
            {
                result = source.Site != null && source.Site.DesignMode;
                source = source.Parent;
            }
            return result;
        }
    }
