    public class DeviceHelper
    {
        public static bool IsTablet(string userAgent, bool isMobile)
        {
            Regex r = new Regex("ipad|android|android 3.0|xoom|sch-i800|playbook|tablet|kindle|nexus");
            bool isTablet = r.IsMatch(userAgent) && isMobile;
            return isTablet;
        }
    }
