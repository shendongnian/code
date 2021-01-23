    public class VirtualServer<TVirtualInfo> : Asset
       where TVirtualInfo : VirtualDeviceInfo
    {
        public TVirtualInfo VirtualProperties
        {
             get;
             set;
        }
    }
    public class VirtualServerInfo : VirtualDeviceInfo
    {
       // properties which are specific to virtual servers, not just devices
    }
