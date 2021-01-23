    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //..........
            var test = new ListViewItem("test");
            backgroundWorker1.ReportProgress(0, test);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listView1.Items.Add((ListViewItem)e.UserState);
        }
