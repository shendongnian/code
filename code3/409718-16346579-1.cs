    public static DataTable ReadExcel(string path)
    {
        //create a DataTable to hold the query results
        DataTable dTable = new DataTable();
        try
        {
            if (!File.Exists(path))
                return null;
            //create the "database" connection string 
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            //create the database query
            string query = "SELECT * FROM [Sheet1$]" ;
            //create an OleDbDataAdapter to execute the query
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connString);
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return dTable;
    }
