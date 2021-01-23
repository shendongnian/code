        private void MyBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                MyBackGroundWorker.ReportProgress(MyDataGridView.Rows.Count);
                if (MyDataGridView.Rows.Count == MyProgressBar.Maximum)
                {
                    break;
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        private void MyBackGroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = MyDataGridView.Rows.Count;
        }
