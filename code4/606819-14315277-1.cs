	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		string inputChar = e.KeyChar.ToString();
		if (inputChar == ".")
		{
			if (textBox1.Text.Trim().Length == 0)
			{
				e.Handled = true;
				return;
			}
			if (textBox1.Text.Contains("."))
			{
				e.Handled = true;
			}
		}
	}
