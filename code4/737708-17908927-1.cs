    bool hasUserClickedClose = false;
    private void MainForm_closing(object sender, FormClosingEventArgs e)
    {
        if (!this.closeable)
        {
            e.Cancel = true; 
            hasUserClickedClose = true;
        }
    }
