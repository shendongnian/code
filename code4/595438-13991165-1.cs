		public class CustomCombo : System.Windows.Forms.ComboBox
	{
		private int _width;
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}
		
		public CustomCombo()
		{
			_width = getWidth(this);
		}
		public int getWidth(System.Windows.Forms.ComboBox combo)
		{
			//do stuff
			return 0;
		}
	}
