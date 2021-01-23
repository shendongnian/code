    public TableLayoutPanel tableLayoutPanel { get; set; }
    
    private void Form_Load(object sender, EventArgs e)
    {
        foreach (Control c in this.tableLayoutPanel.Controls)
        {
            c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
        }
    }
    
    public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e)
    {
    
        MessageBox.Show("Cell chosen: (" + 
                         tableLayoutPanel.GetRow((Control)sender) + ", " + 
                         tableLayoutPanel.GetColumn((Control)sender) + ")");
    }
