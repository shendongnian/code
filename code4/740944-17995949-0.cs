    private void myDataGridView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    	//'#See if the left mouse button was clicked
    	if (e.Button == MouseButtons.Left) {
    		//'#Check the HitTest information for this click location
    		if (myDataGridView.HitTest(e.X, e.Y) == HitTestInfo.Nowhere) {
    			// Do what you want
    		}
    	}
    }
