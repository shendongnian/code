	private void LocalizeShortcuts()
	{
		foreach (KeyGesture keyGuesture in this.InputGestures.OfType<KeyGesture>().ToArray())
		{
			this.InputGestures.Remove(keyGuesture);
			
			System.Windows.Forms.Keys formsKey = (Keys)KeyInterop.VirtualKeyFromKey(keyGuesture.Key);
			if ((keyGuesture.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
			{
				formsKey |= Keys.Alt;
			}
			if ((keyGuesture.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
			{
				formsKey |= Keys.Control;
			}
			if ((keyGuesture.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				formsKey |= Keys.Shift;
			}
			string keyDisplayString = TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString(formsKey);
			this.InputGestures.Add(new KeyGesture(keyGuesture.Key, keyGuesture.Modifiers, keyDisplayString));
		}
	}
