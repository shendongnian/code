    class Program
    {
        static void Main(string[] args)
        {
            killProcess("notepad.exe");
            killProcess("taskmgr");
        }
        public static void killProcess(string name)
        {
            foreach (Process process in Process.GetProcessesByName(name))
            {
                process.Kill();
            }
        }
    }
