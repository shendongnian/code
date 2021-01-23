    DataSet ds = new DataSet();
    sqlAdapter.Fill(ds);
        
    if (ds.Tables[0].Rows.Count == 0)
    {
         pnlQueryResults.Visible = true;
    }
    else
    {
         pnlQueryResults.Visible = false;
    }
