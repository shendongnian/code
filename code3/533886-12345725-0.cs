namespace CSMutex
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool mutexCreated=true;
            using(Mutex mutex = new Mutex(true, "eCS", out mutexCreated))
            {
                if (mutexCreated)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Login loging = new Login();
                    Application.Run(loging);
                    Application.Run(new Main() { UserName = loging.UserName });
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            MessageBox.Show("Another instance of eCS is already running.", "eCS already running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}
