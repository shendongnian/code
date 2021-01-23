	public class PersonRow
	{
		public int RowNum { get; private set; }
		public TextBox NameTextBox { get; private set; }
		public ComboBox CityCombo { get; private set; }
		public ComboBox StateCombo { get; private set; }
		public PersonRow( int rowNum )
		{
			RowNum = rowNum;
			// Create the controls
			NameTextBox = new TextBox();
			CityCombo = new ComboBox();
			StateCombo = new ComboBox();
			// Bind them to this instance
			NameTextBox.Tag = this;
			CityCombo.Tag = this;
			StateCombo.Tag = this;
			//.. continue as in the prev. example..
		}
	}
