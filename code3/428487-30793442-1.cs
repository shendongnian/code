    private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
    	var grid = sender as DataGridView;
    	var rowIdx = (e.RowIndex + 1).ToString();
    	
    	var centerFormat = new StringFormat()
    	{
    		// right alignment might actually make more sense for numbers
    		Alignment = StringAlignment.Center,
    
    		LineAlignment = StringAlignment.Center
    	};
    	//get the size of the string
    	Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);
    	//if header width lower then string width then resize
    	if (grid.RowHeadersWidth < textSize.Width + 40)
    	{
    		grid.RowHeadersWidth = textSize.Width + 40;
    	}
    	var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
    	e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
    }
