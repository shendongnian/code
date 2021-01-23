	List<DataColumn> lsColumns = dtData.Columns
		.Cast<DataColumn>()
		.Where(i => i.DataType == typeof(decimal))
		.ToList()
	//loop through each of our decimal columns
	foreach(DataColumn column in lsColumns)
	{
		//change to double
		column.ChangeType(typeof(double),(value) =>
		{
			double output = 0;
			double.TryParse(value.ToString(), out output);
			return output;	
		});
	}
