    private void updateProgress(object sender, int count, int total)
    {
        if (base.InvokeRequired)
        {
            base.Invoke(new ProcessCountHandler(this.updateProgress), new object[] { sender, count, total });
        }
        else if (count <= this.progressBar1.Maximum)
        {
            this.progressBar1.Value = count;
            this.CompletedCount.Text = count.ToString("N0") + " of " + total.ToString("N0");
        }
    }
