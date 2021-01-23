	public class MyTextBox : TextBox
	{
		protected override bool IsInputKey(Keys keyData)
		{
			return base.IsInputKey(keyData) || ((keyData & ~Keys.Shift) == Keys.Enter && IsDroppedDown);
		}
	}
