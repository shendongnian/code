        DataTable LoadSchemaFromAccess(string szFilePath)
        {
		
		System.Data.OleDb.OleDbCommand cmd;
		try
		{
			System.Data.OleDb.OleDbConnection cnn  = new    System.Data.OleDb.OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data  Source={0};Persist Security Info=False;", szFilePath));
				cnn.Open();
				System.Data.DataTable schemaTable = cnn.GetSchema("Tables");
				cnn.Close();
				return schemaTable;
		}
		catch (exception e)
		{
			MessageBox.Show(e.Message);
			return null;
		}
		finally
		{
			if (cmd != null)
			{
				cmd.Dispose();
			}
		}
    }
        string LoadDataFromAccess(string szTableName )
        {
	 string   GetData = L"SELECT * FROM " + szTableName;
	 System.Data.OleDb.OleDbCommand cmd;
	 string szColumns = "";
	try
	{
		System.Data.OleDb.OleDbConnection cnn = new      System.Data.OleDb.OleDbConnection
			(string.Format(L"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", szPath));
		cnn.Open();
		System.Data.DataTable dt = new System.Data.DataTable();
		OleDbCommand  cmd = new OleDbCommand();
		cmd.Connection = cnn;
		cmd.CommandType = CommandType.Text;
		cmd.CommandText = GetData;
		OleDbDataAdapter adt = new OleDbDataAdapter(cmd);
		adt.SelectCommand = cmd;
		adt.Fill(dt);
		 cnn.Close();
		 return dt;
	}
	catch (exception e)
	{
		MessageBox.Show(e.Message);
		return null;
	}
	finally
	{
		if (cmd != null)
		 {
			cmd.Dispose();
		}
	}
    }
