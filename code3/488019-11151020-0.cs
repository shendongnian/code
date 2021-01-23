	private StringBuilder _pressedKeys = new StringBuilder();
	private void DateTimePicker_BirthDate_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Tab)
		{
			_pressedKeys.Add("Tab");
			return;
		}
		
		if (e.Modifiers == Keys.Shift)
		{
			_pressedKeys.Add("Shift");
			return;
		}
		
		if (_pressedKeys.ToString()."TabShift")
		{
			MessageBox.Show("It works!");
			 _pressedKeys.Clear();
		}
		else
		{
			 _pressedKeys.Clear();
		}
		
		base.OnKeyDown(e);
	}
