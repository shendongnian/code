    private void FrmEditorFormClosing(object sender, FormClosingEventArgs e)
    {
        if(!ConfirmSave())
    	{
    		e.Cancel = true;
    	}	
    }
    
    private void ExitToolStripMenuItemClick(object sender, EventArgs e)
    {
        ConfirmSave();
    
        Close();
    }
