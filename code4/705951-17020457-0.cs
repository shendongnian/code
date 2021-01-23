	protected void btnSave_Click(object sender, EventArgs e)
    {		
		if (String.IsNullOrEmpty(cboDay.SelectedItem.Text)
			|| String.IsNullOrEmpty(cboMonth.SelectedItem.Text)
			|| String.IsNullOrEmpty(cboYear.SelectedItem.Text))
		{
			// TOOD: notify your UI that the values must be supplied
			return;
		}
		
		String str = cboDay.SelectedItem.Text + "/" + cboMonth.SelectedItem.Text + "/" + cboYear.SelectedItem.Text;
		DateTime dt = Convert.ToDateTime(str);
		// ...
    }
