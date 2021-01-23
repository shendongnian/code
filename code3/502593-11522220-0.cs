    DataTable GetSchemaTable() 
    {
		try
		{
            OleDbDataAdapter da; // init adapater with your own connection
            DataSet ds = new DataSet();
			System.Data.DataTable[] dtTables = da.FillSchema(ds, SchemaType.Source);
			return dtTables[0];
		}
		catch (System.Exception se)
		{
			throw new System.Exception("Problem retrieving Schema: " + se.Message);
		}
	}
							
    void CreateSchemaIni(string csvDirectory, string csvFileName) 
    {		
		DataTable dt = GetSchemaTable();
		FileStream fsOutput = new FileStream(csvDirectory + "\\schema.ini", FileMode.Create, FileAccess.Write);
		StreamWriter srOutput = new StreamWriter(fsOutput);
		string s1, s2, s3;
		s1 = "[" + csvFileName + "]";
		s2 = "ColNameHeader=False";
		s3 = "Format=CSVDelimited";
		srOutput.WriteLine(s1 + '\n' + s2 + '\n' + s3 + '\n');
		StringBuilder strB = new StringBuilder();
		for (int i = 1; i <= dt.Columns.Count; i++)
		{
			strB.Append("Col" + i.ToString());
			strB.Append("=F" + i.ToString());
			strB.Append(" Text\n");
			srOutput.WriteLine(strB.ToString());
			strB = new StringBuilder();
		}
		srOutput.Close();
		fsOutput.Close();
	}
