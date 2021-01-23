        public Form1()
        {
            InitializeComponent();
            xlsApp = new Microsoft.Office.Interop.Excel.Application();
            xlsApp.Visible = true;
            int xlsHandle = xlsApp.Hwnd;
            foreach (var p in Process.GetProcesses())
            {
                if (p.MainWindowHandle == new IntPtr(xlsHandle))
                {
                    xlsProcess = p;
                    break;
                }
            }
            if (xlsProcess != null)
            {
                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (xlsApp != null && !xlsApp.Visible)
            {
                xlsApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                xlsApp = null;
            }
            if (xlsProcess.HasExited)
            {
                this.timer.Dispose();
                this.Close();
            }
        }
