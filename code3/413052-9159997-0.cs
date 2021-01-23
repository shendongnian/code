    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.DirectoryServices;
    
    public static class ApplicationPoolRecycle
    {
        public static void RecycleCurrentApplicationPool()
        {
            string appPoolId = GetCurrentApplicationPoolId();
            RecycleApplicationPool(appPoolId);
        }
        private static string GetCurrentApplicationPoolId()
        {
            string virtualDirPath = AppDomain.CurrentDomain.FriendlyName;
            virtualDirPath = virtualDirPath.Substring(4);
            int index = virtualDirPath.Length + 1;
            index = virtualDirPath.LastIndexOf("-", index - 1, index - 1);
            index = virtualDirPath.LastIndexOf("-", index - 1, index - 1);
            virtualDirPath = "IIS://localhost/" + virtualDirPath.Remove(index);
            DirectoryEntry virtualDirEntry = new DirectoryEntry(virtualDirPath);
            return virtualDirEntry.Properties["AppPoolId"].Value.ToString();
        }
        private static void RecycleApplicationPool(string appPoolId)
        {
            string appPoolPath = "IIS://localhost/W3SVC/AppPools/" + appPoolId;
            DirectoryEntry appPoolEntry = new DirectoryEntry(appPoolPath);
            appPoolEntry.Invoke("Recycle");
        }
    }
