	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (FormIsValid())
		{
			if (MessageBox.Show("Do you want to save before exit?", "Closing",
				  MessageBoxButtons.YesNo,
				  MessageBoxIcon.Information) == DialogResult.Yes)
			{
				MessageBox.Show("To Do saved.", "Status",
						  MessageBoxButtons.OK,
						  MessageBoxIcon.Information);
			}
		}
	}
	private bool FormIsValid()
	{
		SEdit se       = this.ActiveMdiChild as SEdit;
		SoEdit soleEdit = this.ActiveControl as SoEdit;
		UppEdit ue      = this.ActiveControl as UpEdit;
		MEdit mat  = this.ActiveControl as MEdit;
		LEdit lse      = this.ActiveControl as LEdit;
		CEdit cle    = this.ActiveControl as CEdit;
		return (se != null || 
		soleEdit != null || 
		ue != null || 
		mat != null || 
		lse != null || 
		cle != null);
	}
