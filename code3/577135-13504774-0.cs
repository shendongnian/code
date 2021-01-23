    DataSet ds = new DataSet();
    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SQL, conn))
    {
        // Format the dates as dd/mm/yyyy
        string date1 = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
        string date2 = DateTime.Now.ToString("dd/MM/yyyy");
        // Set up the SQL with the two date paramters
        string SQL = "SELECT [Req Start Date] FROM [CR$] WHERE [Req Start Date] BETWEEN ? AND ?";
        // Assign the two dates
        dataAdapter.SelectCommand.Parameters.Add("@p1", OleDbType.Date).Value = date1;
        dataAdapter.SelectCommand.Parameters.Add("@p2", OleDbType.Date).Value = date2;
        // Run the query
        dataAdapter.Fill(ds);
    }
