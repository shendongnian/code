		/// <summary>
		/// Changes the datatype of a column. More specifically it creates a new one and transfers the data to it
		/// </summary>
		/// <param name="column">The source column</param>
		/// <param name="type">The target type</param>
		/// <param name="parser">A lambda function for converting the value</param>
		public static void ChangeType(this DataColumn column, Type type, Func<object, object> parser)
		{
			//no table? just switch the type
			if (column.Table == null)
			{
				column.DataType = type;
				return;
			}
			//clone our table
			DataTable clonedtable = column.Table.Clone();
			//get our cloned column
			DataColumn clonedcolumn = clonedtable.Columns[column.ColumnName];
			//remove from our cloned table
			clonedtable.Columns.Remove(clonedcolumn);
			//change the data type
			clonedcolumn.DataType = type;
			//change our name
			clonedcolumn.ColumnName = Guid.NewGuid().ToString();
			//add our cloned column
			column.Table.Columns.Add(clonedcolumn);
			//interpret our rows
			foreach (DataRow drRow in column.Table.Rows)
			{
				drRow[clonedcolumn] = parser(drRow[column]);
			}
			//remove our original column
			column.Table.Columns.Remove(column);
			//change our name
			clonedcolumn.ColumnName = column.ColumnName;
		}
	}
