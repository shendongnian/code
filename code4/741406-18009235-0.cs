	public async Task WriteText(string text)
	{
		TextBoxAutomationPeer peer = new TextBoxAutomationPeer(_textBox);
		IValueProvider valueProvider = peer.GetPattern(PatternInterface.Value) as IValueProvider;
		for(int i = 1; i < text.Length; ++i)
		{
			await Task.Delay(1000); // no need for timer
			valueProvider.SetValue(text.Substring(0, i));
		}
	}
