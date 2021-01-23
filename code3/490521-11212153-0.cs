      int x = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            label1.Text = x.ToString();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            x++;
            //you can put any value
            backgroundWorker1.ReportProgress(0);
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
