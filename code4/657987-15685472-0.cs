    	public class NumericTextBox : TextBox
	{
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			var key = e.KeyChar + "";
			if (key == "\b")
				return;
			double number;
			string newText = Text.Remove(SelectionStart, SelectionLength).Insert(SelectionStart, key);
			if (newText.Length == 1 && key == "-")
				return;
			if (!double.TryParse(newText, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
			{
				e.Handled = true;
			}
		}
		public double Value
		{
			get { return Text.Length == 0 ? 0 : double.Parse(Text, CultureInfo.InvariantCulture); }
		}
	}
