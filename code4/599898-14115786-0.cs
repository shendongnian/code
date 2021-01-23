        private static System.Text.StringBuilder m_sbText;
        public Form3(string path)
        {
            InitializeComponent();
            this._path = path;
            Process myProcess = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("pawncc.exe");
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.Arguments = path + " -r -d2";
            myProcess.StartInfo = startInfo;
            myProcess.Start();
            m_sbText = new System.Text.StringBuilder(1000);
            myProcess.OutputDataReceived += ProcessDataHandler;
            myProcess.ErrorDataReceived += ProcessDataHandler;
            myProcess.Start();
            myProcess.BeginOutputReadLine();
            myProcess.BeginErrorReadLine();
            while (!myProcess.HasExited)
            {
                System.Threading.Thread.Sleep(500);
                System.Windows.Forms.Application.DoEvents();
            }
            RichTextBox1.Text = m_sbText.ToString();
        }
        private static void ProcessDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the net view command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                // Add the text to the collected output.
                m_sbText.AppendLine(outLine.Data);
            }
        }
