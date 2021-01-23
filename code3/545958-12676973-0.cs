        private void btnMonitor_Click(object sender, EventArgs e)
        {
            var proc = Process.GetProcesses().Where(p => p.ProcessName.IndexOf(this.txtProcessName.Text) > -1);
            var k = 1;
            var appendSuffix = proc.Count() > 1;
            this.pcs = new List<PerformanceCounter>();
            foreach (var p in proc)
            {
                this.pcs.Add(new PerformanceCounter(
                    "Process",
                    "% Processor Time",
                    appendSuffix ? string.Format("{0}#{1}", p.ProcessName, k) : p.ProcessName,
                    true));
                this.lstbxPC.Items.Add(appendSuffix ? string.Format("{0}#{1}", p.ProcessName, k) : p.ProcessName);
                k++;
            }
            this.checkProcess = new Thread(this.CheckProcess);
            this.checkProcess.Start();
        }
        private void CheckProcess()
        {
            while (true)
            {
                var temp = 0;
                foreach (var pc in this.pcs)
                {
                    var nextValue = pc.NextValue();
                    if (temp < nextValue)
                    {
                        temp = (int)nextValue;
                    }
                }
                // Set the label in a ThreadSafe way. This does work.
                SetControlPropertyThreadSafe(lblCPU, "Text", Convert.ToString(temp) + "%");
                Thread.Sleep(1000);
            }
        }
