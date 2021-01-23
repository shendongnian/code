	private void TextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
			{
				MessageBox.Show("Control + Enter pressed");
			}
			else if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
			{
				MessageBox.Show("Shift + Enter pressed");
			}
		}
	}
