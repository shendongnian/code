    	public class RectangleHotSpot : System.Web.UI.WebControls.HotSpot
	{
		private string _strAlt;
		public override string AlternateText
		{
			get
			{
				return _strAlt;
			}
			set
			{
				this._strAlt = value;
			}
		}
		public override string GetCoordinates()
		{
			return String.Empty; // You'll need to fill this in.
		}
		protected override string MarkupName
		{
			get { return String.Empty; } // This too.
		}
	}
