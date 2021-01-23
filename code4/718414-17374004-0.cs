	private void OnValidatingUserControl(object sender, CancelEventArgs args)
	{
	  if (IsTextBoxInvalid())
	  {
		args.Cancel = true;
		GlobalVariables.UserControlValidationError = true;
		MessageBox.Show("Invalid data in text box!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		this.textBox.Focus();
	  }
	  else
	  {
		GlobalVariables.UserControlValidationError = false;
	  }
	}
