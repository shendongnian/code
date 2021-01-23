    private void BackgroundThreadWork(object sender, DoWorkEventArgs e)
    {
        while (!_worker.CancellationPending)
        {
            string[] tmpStrPort = System.IO.Ports.SerialPort.GetPortNames();
            IEnumerable<string> diff = tmpStrPort.Except(strPort);
            strPort = tmpStrPort;
            System.Console.WriteLine(System.IO.Ports.SerialPort.GetPortNames().Length);
            foreach (string p in diff)
            {
                _worker.ReportProgress(1, p);
            }                
        }
    }
