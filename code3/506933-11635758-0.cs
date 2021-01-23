	public class DataTableHelper
	{
		class RowItem
		{
			public string Name { get; set; }
			public object Value { get; set; }
		}
		public IEnumerable<RowItem> Convert(System.Data.DataTable table)
		{
			string[] columns = (from System.Data.DataColumn n in table.Columns select n.ColumnName).ToArray();
			foreach (System.Data.DataRow row in table.Rows)
			{
				foreach (string column in columns)
					yield return new RowItem() { Name = column, Value = row[column] };
			}
		}
	}
