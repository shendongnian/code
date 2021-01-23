    private void CreateImageGrid(DataTable dtDataSource)
    {
    	int colCount = 5;
    	int rowCount = 0;
    	int imgWidth = 100;
    	int imgHeight = 100;
    	int imgPadding = 10;
    	int lblPadding = 5;
    	int ind = -1;
    
    	PictureBox pic = null;
    	Label lbl = null;
    
    	if (dtDataSource.Rows.Count > colCount)
    	{
    		rowCount = Convert.ToInt32(dtDataSource.Rows.Count / colCount);
    
    		if (Convert.ToInt32(dtDataSource.Rows.Count % colCount) > 0)
    		{
    			rowCount++;
    		}
    	}
    	else
    	{
    		rowCount = 1;
    	}
    
    	for (int j = 0; j < rowCount; j++)
    	{
    		for (int i = 0; i < colCount && dtDataSource.Rows.Count > ((j * colCount) + i); i++)
    		{
    			ind = (j * colCount) + i;
    
    			pic = new PictureBox();
    			pic.Image = Image.FromFile(dtDataSource.Rows[ind]["Path"].ToString());
    
    			pnlGrid.Controls.Add(pic);
    
    			pic.Width = imgWidth;
    			pic.Height = imgHeight;
    			pic.Top = (j * (imgHeight + imgPadding)) + imgPadding;
    			pic.Left = (i * (imgWidth + imgPadding)) + imgPadding;
    
    			lbl = new Label();
    			lbl.Text = dtDataSource.Rows[ind]["Name"].ToString();
    
    			pnlGrid.Controls.Add(lbl);
    
    			lbl.Left = pic.Left;
    			lbl.Top = pic.Top + pic.Height + lblPadding;
    		}
    	}
    }
