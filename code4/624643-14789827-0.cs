    private int thCount = 0;
        private void gridOperations_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && thCount==5)
	        {
                //... 
                thCount = 0;
            }
	        else
	        {
		        thCount++;
            }
	    }
