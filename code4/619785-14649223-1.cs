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
		return 
		(this.ActiveMdiChild as SEdit) != null ||
		(this.ActiveControl as SoEdit) != null ||
		(this.ActiveControl as UpEdit) != null ||
		(this.ActiveControl as MEdit)  != null ||
		(this.ActiveControl as LEdit)  != null ||
		(this.ActiveControl as CEdit)  != null;
	}
