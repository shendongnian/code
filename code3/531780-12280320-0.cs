        Process proc = new Process();
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process proc1 = new System.Diagnostics.Process();
            proc1.StartInfo.FileName = "C:\\windows\\SysWOW64\\shutdown.exe";
            proc1.StartInfo.Arguments = "/l";
            proc1.StartInfo.UseShellExecute = false;
            proc1.StartInfo.RedirectStandardOutput = false;
            proc1.Start();
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(@"K:\App\pc\stub.exe");
            p.Arguments = "-RunForever";
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo = p;
            proc.StartInfo.CreateNoWindow = true;
            proc.EnableRaisingEvents = true;
            proc.Exited += new EventHandler(myProcess_Exited);
            proc.Start();
        }
