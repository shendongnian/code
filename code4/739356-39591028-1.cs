    [STAThread]
    public void MessageBoxShow(string errorMessage)
    {
    	using (frmError errorForm = new frmError(errorMessage))
    	{
    		errorForm.ShowDialog();
    	}
    }
