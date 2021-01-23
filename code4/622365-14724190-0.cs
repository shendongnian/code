    private void btnAutoResizeContactNameColumn_Click(object sender, EventArgs e)
    {
	// Perform Auto Resize on Contact column
	this.ultraGrid1.DisplayLayout.Bands[0].Columns["ContactName"].PerformAutoResize();
    }
