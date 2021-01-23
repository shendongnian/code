	public class SerializableBusinessCard
	{
		public SerializableBusinessCard()		{ }
		public string Name						{ get; set; }
		public string Company					{ get; set; }
		public List<string> Labels				{ get; set; }
		public List<ComboItem> ComboBoxes		{ get; set; }
		
	}
	
	public class ComboItem
	{	
		public ComboItem()				{ }
		public string Name				{ get; set; }
		public string Text				{ get; set; }
		public int SelectedIndex		{ get; set; }
		public Point Location			{ get; set; }
		public Size size					{ get; set; }
		public List<string> Collection{ get; set; }
	}
