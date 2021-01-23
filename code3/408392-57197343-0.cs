/// <summary>
///     Converts a column in a DataTable to another type using a user-defined converter function.
/// </summary>
/// <param name="dt">The source table.</param>
/// <param name="columnName">The name of the column to convert.</param>
/// <param name="valueConverter">Converter function that converts existing values to the new type.</param>
/// <typeparam name="TTargetType">The target column type.</typeparam>
public static void ConvertColumnTypeTo<TTargetType>(this DataTable dt, string columnName, Func<object, TTargetType> valueConverter)
{
	var newType = typeof(TTargetType);
	
	DataColumn dc = new DataColumn(columnName + "_new", newType);
	
	// Add the new column which has the new type, and move it to the ordinal of the old column
	int ordinal = dt.Columns[columnName].Ordinal;
	dt.Columns.Add(dc);
	dc.SetOrdinal(ordinal);
	// Get and convert the values of the old column, and insert them into the new
	foreach (DataRow dr in dt.Rows)
	{
		dr[dc.ColumnName] = valueConverter(dr[columnName]);
	}
	// Remove the old column
	dt.Columns.Remove(columnName);
	// Give the new column the old column's name
	dc.ColumnName = columnName;
}
This way, usage is a lot more straightforward, while also customizable:
DataTable someDt = CreateSomeDataTable();
// Assume ColumnName is an int column which we want to convert to a string one.
someDt.ConvertColumnTypeTo<string>('ColumnName', raw => raw.ToString());
