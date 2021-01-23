    public List<DataTable> GetWithQuery(string query)
    {
        DataTable dataTable = new DataTable();
        using (OleDbConnection source = new
            OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data
            Source=C:\Users\Duncan\Documents\Visual Studio
            2012\Projects\TheatreUI\TheatreUI\bin\Debug\PlayHouse.accdb"))
        {
            using (OleDbCommand sourceCommand = new OleDbCommand(query, source))
            {
                source.Open();
                using (OleDbDataReader dr = sourceCommand.ExecuteReader())
                {
                    try
                    {
                        dataTable.Load(dr);
                    }
                    catch (Exception)
                    {
                        //Do nothing
                    }
                    finally
                    {
                        source.Close();
                    }
                }
            }
        }
        return dataTable;
    }
