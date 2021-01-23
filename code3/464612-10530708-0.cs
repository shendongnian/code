	//http://msdn.microsoft.com/en-us/library/ms135981.aspx
        //Or Microsoft.Jet.OLEDB.4.0
	OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; "
	   + "Data Source=" + pathToAccessDb);
	cn.Open();
	//Retrieve schema information
	DataTable columns = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Indexes,
				 new Object[] { null, null, null, null, "Table1" });
	foreach (DataRow row in columns.Rows)
	{
	   Console.WriteLine(row["COLUMN_NAME"].ToString());
	   Console.WriteLine(row["TABLE_NAME"].ToString());
	   Console.WriteLine(row["UNIQUE"].ToString());
	}
	cn.Close();
	//Pause
	Console.ReadLine();
