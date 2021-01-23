	public class Table
	{
		public Table(String name)
		{
			this.Name = name;
			this.ContentRows = new List<TableRow>();
			this.HeaderRow = new TableRow();
			this.FooterRow = new TableRow();
		} 
		
		public IList<TableRow> ContentRows
		{
			get;
			private set;
		}
		public TableRow FooterRow
		{
			get;
			private set;
		}
		public TableRow HeaderRow
		{
			get;
			private set;
		}
		public String Name
		{
			get;
			private set;
		}
	}
