    private void btnsend_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
            if (bgw.IsBusy == false)
            {
                bgw.RunWorkerAsync();
            }
        }
        private void Update(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(Update), new Object[] { i });
                return;
            }
            using (var sp = new SerialPort(cbcomport.Text))
            {
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                sp.WriteLine("AT+CMGS=\"" + dt.Rows[i]["PhoneNo"] + "\"" + Environment.NewLine);
                sp.WriteLine(tbsms.Text + (char)26);
                if (sp.BytesToRead > 0)
                {
                    tbsentto.Text = i + 1 + " of " + dt.Rows.Count;
                }
            }
        }        
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Update(i);
                Thread.Sleep(5000);
            }
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
        }
