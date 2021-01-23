    public DataSet CreateTable(string source)
    {
        using (var connection = new OleDbConnection(GetConnectionString(source, true)))
        {
            var dataSet = new DataSet();
            connection.Open();
            var schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (schemaTable == null)
                return dataSet;
    
            var sheetName = "";
            foreach (DataRow row in schemaTable.Rows)
            {
                sheetName = row["TABLE_NAME"].ToString();
                break;
            }
    
            var command = string.Format("SELECT * FROM [{0}$]", sheetName);
            var adapter = new OleDbDataAdapter(command, connection);
            adapter.TableMappings.Add("TABLE", "TestTable");
            adapter.Fill(dataSet);
            connection.Close();
    
            return dataSet;
        }
    }
    
    //
    
    private string GetConnectionString(string source, bool hasHeader)
    {
        return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};
        Extended Properties=\"Excel 12.0;HDR={1};IMEX=1\"", source, (hasHeader ? "YES" : "NO"));
    }
