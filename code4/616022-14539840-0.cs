    public MainForm()
    {
        this.Shown += new System.EventHandler(this.MainForm_Shown);
    }
    private void MainForm_Shown(object sender, EventArgs e)
    {
        MessageBox.Show("Everything is loaded");
    }
