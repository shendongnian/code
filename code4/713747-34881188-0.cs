    public static bool CheckTexfieldMaxLength (UITextField textField, NSRange range, string replacementString, int maxLength)
		{
			int maxLength = 10;
			int newLength = (textField.Text.Length - (int)range.Length) + replacementString.Length;
			if (newLength <= maxLength) {
				return true;
			} else {
				if (range.Length == 0 && range.Location > 0 && replacementString.Length > 0 && textField.Text.Length >= maxLength)
					return false;
				int emptySpace = maxLength - (textField.Text.Length - (int)range.Length);
				textField.Text = textField.Text.Substring (0, (int)range.Location)
				+ replacementString.Substring (0, emptySpace)
				+ textField.Text.Substring ((int)range.Location + (int)range.Length, emptySpace >= maxLength ? 0 : (maxLength - (int)range.Location - emptySpace));
				return false;
			}
		}
