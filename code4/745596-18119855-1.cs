    using System.Diagnostics;
    
    void ShowElapsedTime()
    {
            FILETIME lpCreationTime;
            FILETIME lpExitTime;
            FILETIME lpKernelTime;
            FILETIME lpUserTime;
            if (GetProcessTimes(Process.GetCurrentProcess().Handle, out lpCreationTime, out lpExitTime, out lpKernelTime, out lpUserTime))
            {
                DateTime creationTime = FileTimeToDateTime(lpCreationTime);
                TimeSpan elapsedTime = DateTime.Now.Subtract(creationTime);
                MessageBox.Show(elapsedTime.TotalSeconds.ToString());
            }
    }
