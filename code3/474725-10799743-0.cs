        private static string GetAppDataDirectoryForTesting()
        {   //NOTE: must be using visual studio test tools for this to work
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var dirs = path.Split(Path.DirectorySeparatorChar);
            var appDataPath = "";
            for (int i = 0; i < dirs.Length - 3; i++)
            {
                appDataPath += dirs[i] + Path.DirectorySeparatorChar.ToString();
            }
            appDataPath = appDataPath + "[foldername(i.e. in my case project name)]" + Path.DirectorySeparatorChar.ToString() + "App_Data";
            return appDataPath;
        }
