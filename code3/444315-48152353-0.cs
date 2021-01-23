    using System;
    namespace Utilities
    {
        public static class MyProfile
       {
            public static string Path(string target)
            {
                string basePath = 
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + 
    @"\Automation\";
                return basePath + target;
            }
        }
    }
