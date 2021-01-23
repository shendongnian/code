	private void ThisApplication_Startup(object sender, System.EventArgs e)
	{
		this.ActiveExplorer().SelectionChange += () => {	
			MessageBox.Show("Selection Changed")
		};
	}
