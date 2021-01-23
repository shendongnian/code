    static void Main()
    {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyFirstWindow fw = null;
            do
            {
                fw = new MyFirstWindow();
                Application.Run(fw);
            } while (!fw.checked);
            Application.Run(new MyNextWindow());
        }
