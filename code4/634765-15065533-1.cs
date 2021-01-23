	class CustomTextbox : TextBox
	{
		private ControlType _controlType;
		public CustomTextbox()
		{
			Controltype = ControlType.Number;
		}
		public ControlType Controltype
		{
			get { return _controlType; }
			set
			{
				switch (value)
				{
					case ControlType.Number:
						KeyPress += textboxNumberic_KeyPress;
						MaxLength = 13;
						break;
					case ControlType.Text:
						KeyPress += TextboxTextKeyPress;
						MaxLength = 100;
						break;
				}
				_controlType = value;
			}
		}
		private void textboxNumberic_KeyPress(object sender, KeyPressEventArgs e)
		{
			const char delete = (char)8;
			const char plus = (char)43;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != delete && e.KeyChar != plus;
		}
		private void TextboxTextKeyPress(object sender, KeyPressEventArgs e)
		{
			const char delete = (char)8;
			const char plus = (char)43;
			e.Handled = Char.IsDigit(e.KeyChar);
		}
	}
	public enum ControlType
	{
		Number,
		Text,
	}
