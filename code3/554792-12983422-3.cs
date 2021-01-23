    public partial class Form1 : Form
	{
		FormattableTextBoxColumn firstNameColumn = new FormattableTextBoxColumn();
		FormattableTextBoxColumn lastNameColumn = new FormattableTextBoxColumn();
		public Form1()
		{
			InitializeComponent();
			// add first name col
			firstNameColumn.MappingName = "FirstName";
			dataGridTableStyle1.GridColumnStyles.Add(firstNameColumn);
			firstNameColumn.SetCellFormat += new FormatCellEventHandler(ColumnSetCellFormat);
			// add last name col
			lastNameColumn.MappingName = "LastName";
			lastNameColumn.SetCellFormat += new FormatCellEventHandler(ColumnSetCellFormat);
			dataGridTableStyle1.GridColumnStyles.Add(lastNameColumn);
			// This just sets up a dummy data source, since I don't have a database in this example
			List<PersonTest> peopleList = new List<PersonTest>();
			peopleList.Add(new PersonTest
			{
				FirstName = "Alan",
				LastName = "McCormick",
				HighlightPerson = true
			});
			peopleList.Add(new PersonTest
			{
				FirstName = "John",
				LastName = "Smith",
				HighlightPerson = false
			});
			BindingSource peopleDataSource = new BindingSource();
			peopleDataSource.DataSource = peopleList;
			dataGridTableStyle1.MappingName = peopleDataSource.GetListName(null);
			dataGrid1.DataSource = peopleDataSource;
		}
		// I'll cache this brush in the form, just make sure to dispose it (see designer.cs disposing)
		SolidBrush highlightBrush = new SolidBrush(Color.Yellow);
		// here is the event you can handle to determine the color of your row!
		private void ColumnSetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			if ((e.Source.List[e.Row] as PersonTest).HighlightPerson)
				e.BackBrush = highlightBrush;
		}
		// example test class
		public class PersonTest
		{
			public String FirstName { get; set; }
			public String LastName { get; set; }
			public bool HighlightPerson { get; set; }
		}
	}
