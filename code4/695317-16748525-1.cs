    private void GetServerReady()
        {
            if (!bW.IsBusy)
            {
                bW.RunWorkerAsync();
                txtBxHistory.Text += "\r\n" + Output;
            }
        }
        private void bW_DoWork(object sender, DoWorkEventArgs e)
        {
            Looper();
        }
        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            GetServerReady();
        }
