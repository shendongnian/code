	public class PassingID2
	{
		private string _Text = null;
		public string Text
		{
			get { return _Text; }
			set { if (_Text.Length <= 0) _Text = value; }
		}
	}
	public class PassingID1
	{
		public string Text { get; set; }
	}
