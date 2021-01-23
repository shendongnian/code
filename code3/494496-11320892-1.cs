	Program.MainForm = new MainForm();
	try
	{
		MessageBox.Show("Login Success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Abusing LoginForm's Invoke method.  Code assumes LoginForm is always available.
		Program.LoginForm.Invoke((MethodInvoker)delegate
		{
			Program.MainForm.Show();
		});
	}
	catch (Exception Ex)
	{
		MessageBox.Show(Ex.ToString()); //Debuging purposes
	}
