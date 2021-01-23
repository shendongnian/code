        DataTable datatable = new DataTable();
        System.Data.OleDb.OleDbDataAdapter oAdapter = new System.Data.OleDb.OleDbDataAdapter();
        oAdapter.Fill(datatable,ReadOnlyVariables["User::XXXXX"]);
        foreach (DataRow row in datatable.Rows)
        {
            Output0Buffer.AddRow();
            Output0Buffer.CoverAmount = Convert.ToInt32(row["XXXX"].ToString());
        } 
