    ChildForm frmDLg = null;
    public MainForm()
    {
    	this.VisibleChanged += MainFrmVisibleChanged;
    }
    
    private void LoadDialogForm()
    {
    	try {
    		if (frmDLg == null || frmDLg.IsDisposed) {
    			frmDLg = new ChildForm();
    		}
    		frmDLg.ShowDialog();
    	} catch (Exception ex) {
    		//Handle exception
    	}
    }
    
    private void MainFrmVisibleChanged(object sender, System.EventArgs e)
    {
    	if (frmDLg != null && !frmDLg.IsDisposed) {
    		frmDLg.TopMost = this.Visible;
    	}
    }
