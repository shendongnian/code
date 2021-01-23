	public static class DataColumnExtensions
	{
		public static DataColumn CopyTo(this DataColumn column, DataTable table)
		{
			DataColumn newColumn = new DataColumn(column.ColumnName, column.DataType, column.Expression, column.ColumnMapping);
			newColumn.AllowDBNull = column.AllowDBNull;
			newColumn.AutoIncrement = column.AutoIncrement;
			newColumn.AutoIncrementSeed = column.AutoIncrementSeed;
			newColumn.AutoIncrementStep = column.AutoIncrementStep;
			newColumn.Caption = column.Caption;
			newColumn.DateTimeMode = column.DateTimeMode;
			newColumn.DefaultValue = column.DefaultValue;
			newColumn.MaxLength = column.MaxLength;
			newColumn.ReadOnly = column.ReadOnly;
			newColumn.Unique = column.Unique;
	
			table.Columns.Add(newColumn);
			
			return newColumn;
		}
	}
	public class MyClass
	{
		public static void Main()
		{
			DataTable tableA = new DataTable("TableA");
			tableA.Columns.Add("Column1", typeof(int));
			tableA.Columns.Add("Column2", typeof(string));
			
			DataTable tableB = new DataTable("TableB");
			
			foreach (DataColumn column in tableA.Columns)
			{
				column.CopyTo(tableB);
			}
		}
	}
