        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = fillnotification();
        }
        public int fillnotification()
        {
            if (Program.USERPK != 0)
            {
                DataTable dt = nftrans.getnotification();
                return dt.Rows.Count;
            }
            return -1;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int pending = (int)e.Result;
            if (pending != -1)
            {
                String message = "You Have  " + pending.ToString() + " Applications Pending For Approval";
                toolTip1.Show(message, this, lblStatus.Location);
            }
        }
