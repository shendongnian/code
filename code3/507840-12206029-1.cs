	public override void OnCommand(IVsTextView textView, VsCommands2K command, char ch)
	{
		if (textView == null || this.LanguageService == null 
			|| !this.LanguageService.Preferences.EnableCodeSense)
			return;
		if (command == Microsoft.VisualStudio.VSConstants.VSStd2KCmdID.TYPECHAR)
		{
			if (char.IsLetterOrDigit(ch))
			{
				//do something cool
			}
		}
		base.OnCommand(textView, command, ch);
	}
