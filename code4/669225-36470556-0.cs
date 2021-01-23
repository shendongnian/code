    static void Main()
    {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyFirstWindow fw = new MyFirstWindow();
            do
            {
                Application.Run(fw);
            } while (fw.checked);
            Application.Run(new MyNextWindow());
        }
