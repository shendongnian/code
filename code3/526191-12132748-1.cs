    public class ScreenSaverCheck
    {
        public static bool IsScreenSaverRunning()
        {
            Process[] FullProcessList = Process.GetProcesses();
            try
            {
                foreach (Process ProcessFromList in FullProcessList)
                {
                    if (ProcessFromList.ProcessName.EndsWith(".scr"))
                    {
                        return true;
                    }
                }
            }
            finally
            {
                foreach (Process ProcessFromList in FullProcessList)
                {
                    ProcessFromList.Dispose();
                }
            }
            return false;
        }
    }
