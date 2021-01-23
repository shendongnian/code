	private class MyTextDel : NSTextFieldDelegate
	{
		public override bool DoCommandBySelector (
			NSControl control, 
			NSTextView textView, 
			Selector commandSelector)
		{
			if (commandSelector.Name == "insertNewline:") {
				textView.InsertText (new NSString (Environment.NewLine));
				return true;
			}
			return false;
		}
	}
