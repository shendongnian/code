    class Tee
    {
        private readonly string m_programPath;
        private readonly string m_logPath;
        private TextWriter m_writer;
    
        public Tee(string programPath, string logPath)
        {
            m_programPath = programPath;
            m_logPath = logPath;
        }
    
        public void Run()
        {
            using (m_writer = new StreamWriter(m_logPath))
            {
    
                var process =
                    new Process
                    {
                        StartInfo =
                            new ProcessStartInfo(m_programPath)
                            { RedirectStandardOutput = true, UseShellExecute = false }
                    };
    
                process.OutputDataReceived += OutputDataReceived;
    
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
            }
        }
    
        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            m_writer.WriteLine(e.Data);
        }
    }
