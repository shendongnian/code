    string CONNECTION_STRING = "Persist Security Info=False; Integrated Security = SSPI; Initial Catalog=DATABASENAME;Data Source=SERVERIP";
    string query = "IF OBJECT_ID('TABLE_NAME') IS NOT NULL SELECT * FROM TABLE_NAME";
    using (SqlConnection Connection = new SqlConnection(CONNECTION_STRING))
    {
        using (SqlCommand sqlCommand = new SqlCommand(query, ConnectionString))
        {
            try
            {
                Connection.Open();
                SqlDataReader queryCommandReader = sqlCommand.ExecuteReader();
		        DataTable dataTable = new DataTable();
		        dataTable.Load(queryCommandReader);
						
		        if (dataTable != null)
		        {
		             if (dataTable.Rows != null)
		             {
			             if (dataTable.Rows.Count > 0)
			             {
		                     String rowText = "";
			                 rowText += dataTable.Rows[ROW_NUM] [COLUMN_NAME];							
			             }
		             }
		        }
	        }
	        catch (Exception)
	        {
                ...
            }
	        finally
	        {
                   ...
	        }
