    private  void button1(object sender, EventArgs e)
    {
        txtOutput.Text += "Auto-collecting variables. This may take several minutes";
        Task.Factory.StartNew(() => foo())
            .ContinueWith(t => txtOutput.Text += "\n" + t.Result
                , TaskScheduler.FromCurrentSynchronizationContext())
            .ContinueWith(t => bar())
            .ContinueWith(t =>
            {
                txtOutput.Text += "\n" + t.Result;
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret(); //scrolls to the bottom of textbox
            }
                , TaskScheduler.FromCurrentSynchronizationContext());
    }
