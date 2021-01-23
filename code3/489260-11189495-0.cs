        private void ScanP()
        {
            int startPort = Convert.ToInt32(txtFrom.Text);
            int endPoint = Convert.ToInt32(txtTo.Text);
            progressBar1.Value = 0;
            progressBar1.Maximum = endPoint - startPort + 1;
            var scans = from i in Enumerable.Range(startPort, 
                                                   endPoint - startPort + 1)
                        select ScanSinglePortTask(i)
                            .ContinueWith(t => Report(t.Result),
                                TaskScheduler.FromCurrentSynchronizationContext());
            var tasks=scans.ToArray();
        }
        private Task<string> ScanSinglePortTask(int currPort)
        {
            return Task.Factory.StartNew(() =>
                {
                    try
                    {
                        using (var tcpportScan = new TcpClient())
                        {
                            tcpportScan.SendTimeout = 10;
                            tcpportScan.Connect(txtIPaddress.Text, (int) currPort);
                        }
                        return "Port " + currPort + " open.\n";
                    }
                    catch (Exception)
                    {
                        return "Port " + currPort + " closed.\n";
                    }
                }, TaskCreationOptions.LongRunning);
        }
        private void Report(object message)
        {
            txtDisplay.AppendText((string)message);
            progressBar1.PerformStep();
        }
