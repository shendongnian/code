	public class AdvancedComboBox : ComboBox
	{
		private int myPreviouslySelectedIndex = -1;
		private int myLocalSelectedIndex = -1;
		public int PreviouslySelectedIndex { get { return myPreviouslySelectedIndex; } }
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			myPreviouslySelectedIndex = myLocalSelectedIndex;
			myLocalSelectedIndex = SelectedIndex;
			base.OnSelectedIndexChanged(e);
		}
	}
