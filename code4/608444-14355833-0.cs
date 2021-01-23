        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;
            Mutex mutex = new Mutex(true, "Global\\"+sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();
            return !bCreatedNew;
        }
