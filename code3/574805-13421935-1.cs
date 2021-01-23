    DataTable table = new DataTable();
	table.Columns.Add("UID", typeof(int));
	table.Columns.Add("SL", typeof(int));
	table.Columns.Add("SP", typeof(string));
	table.Columns.Add("MA", typeof(boolean));
	table.Rows.Add(sqlCmd.Parameters["@UID"].Value, sqlCmd.Parameters["@SL"].Value, sqlCmd.Parameters["@SP"].Value, sqlCmd.Parameters["@MA"].Value);
    CustomerGrid.DataSource = table
