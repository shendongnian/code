    private void Form_Load(object sender, EventArgs e)
    {
	    foreach (Panel space in this.tableLayoutPanel.Controls)
	    {
	    	space.MouseClick += new MouseEventHandler(clickOnSpace);
	    }
    }
    public void clickOnSpace(object sender, MouseEventArgs e)
    {
        MessageBox.Show("Cell chosen: (" + 
                         tableLayoutPanel.GetRow((Panel)sender) + ", " + 
                         tableLayoutPanel.GetColumn((Panel)sender) + ")");
	}
