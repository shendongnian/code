    static void Main()
    {
        Application.EnableVisualStyles();
        bool exclusive;
        System.Threading.Mutex appMutex = new System.Threading.Mutex(true, "MY_APP", out exclusive);
        if (!exclusive)
        {
             MessageBox.Show("Another instance of xxxx xxxBuilder is already running.","MY_APP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation );
                        return;
        }
        Application.SetCompatibleTextRenderingDefault(false);
        xxxWindowsApplication.InitializeApplication();
        Application.Run(new frmMenuBuilderMain());
                    GC.KeepAlive(appMutex);
                }
