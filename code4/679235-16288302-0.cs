    public partial class Form1 : Form
    {
        private Thread myThread = null;
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void ProgressDelegate(string message, int percent);
        public void DisplayProgess(string message, int percent)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ProgressDelegate(DisplayProgess), new Object[] { message, percent });
            }
            else
            {
                this.statusBar1.Text = message;
                this.progressBar1.Value = percent;
            }
        }
        public delegate bool IsCheckedDelegate(CheckBox cb);
        public bool IsChecked(CheckBox cb)
        {
            if (cb.InvokeRequired)
            {
                return (bool)cb.Invoke(new IsCheckedDelegate(IsChecked), new Object[] { cb });
            }
            else
            {
                return cb.Checked;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (myThread == null)
            {
                button1.Enabled = false;
                myThread = new Thread(MyWorkerThread);
                myThread.IsBackground = true;
                myThread.Start();
            }
        }
        private void MyWorkerThread()
        {
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"Software\Apps\Microsoft .NET CF 3.5"))
            {
                if (Key != null)
                {
                    if (this.IsChecked(checkBox2))
                    {
                        MessageBox.Show("Framework Exist, Wireless apps Enabled");
                        appcenter();
                        oac();
                    }
                    else
                    {
                        MessageBox.Show("Framework exist and NOT installing wireless apps.");
                        appcenter();
                    }
                }
                else
                {
                    if (this.IsChecked(checkBox2))
                    {
                        MessageBox.Show("Framework not found,Installing with wireless");
                        NETCFv351();
                        NETCFv352();
                        sqlce1();
                        sqlce2();
                        sqlce3();
                        appcenter();
                        oac();
                    }
                    else
                    {
                        MessageBox.Show("Installing everything with NO wireless");
                        NETCFv351();
                        NETCFv352();
                        sqlce1();
                        sqlce2();
                        sqlce3();
                        appcenter();
                    }
                }
            }
        }
        public void RunCabAndWait(string CabToRun)
        {
            string cab = "\\Program Files\\cabs\\" + CabToRun;
            string parm = @"/delete 1 """ + cab + @""" /silent";
            Process.Start(new ProcessStartInfo(@"wceload.exe", parm)).WaitForExit();
        }
        // NETCFv35.Messages.EN.wm.cab
        public void NETCFv351()
        {
            this.DisplayProgess("Installing NET3.5 Framework", 10);
            Thread.Sleep(1000);
            this.RunCabAndWait("NETCFv351.cab");
        }
        //NETCFv35.Messages.EN.wm.cab
        public void NETCFv352()
        {
            this.RunCabAndWait("NETCFv352.cab");
        }
        //sqlce.ppc.wce5.armv4i.CAB
        public void sqlce1()
        {
            this.RunCabAndWait("sqlce1.cab");
        }
        //sqlce.repl.ppc.wce5.armv4i.CAB
        public void sqlce2()
        {
            this.RunCabAndWait("sqlce2.cab");
        }
        //sqlce.dev.ENU.ppc.wce5.armv4i.CAB
        public void sqlce3()
        {
            this.RunCabAndWait("sqlce3.cab");
            Thread.Sleep(1000);
            this.DisplayProgess("NET3.5 Framework Installed", 30);
        }
        public void appcenter()
        {
            Thread.Sleep(700);
            this.RunCabAndWait("appcenter.cab");
            Thread.Sleep(700);
            this.DisplayProgess("Appcenter Installed", 35);
        }
        public void oac()
        {
            this.RunCabAndWait("oac.cab");
            Thread.Sleep(700);
            this.DisplayProgess("Odyssey Installed", 65);
        }
    }
