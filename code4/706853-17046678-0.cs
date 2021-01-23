	string mystring = "Category3,Category4,Category6";
	string[] myarray = mystring.Split(",".ToCharArray());
	DataTable table = new DataTable();
	table.Columns.Add("Value", typeof(string));
	for (int i = 0; i < myarray.Length; i++)
	{
		var row = table.NewRow();
		row[0] = myarray[i];
		table.Rows.Add(row);
	}
