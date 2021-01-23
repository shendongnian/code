    public class DeviceConfig
    {
        public static void RegisterDevices(IList<IDisplayMode> modes)
        {
            //The Android view
            modes.Insert(0, new DefaultDisplayMode("android")
            {
                ContextCondition = Context => Context.GetOverriddenUserAgent().Contains("Android")
            });
            //The iPhone view
            modes.Insert(1, new DefaultDisplayMode("iphone")
            {
                ContextCondition = Context => Context.Request.Browser.MobileDeviceModel == "IPhone"
            });
            //The mobile view
            //This has a lower priority than the other two so will only be used by a mobile device
            //that isn't Android or iPhone
            modes.Insert(2, new DefaultDisplayMode("mobile")
            {
                ContextCondition = Context => Context.Request.Browser.IsMobileDevice
            });
        }
    }
