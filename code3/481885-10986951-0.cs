    for( int i = 0; i < ds.Tables["Invoices"].Rows.Count; i++ )
    {
        if( i > 0 )
        {
           // Compare with previous row using index
           if( ds.Tables["Invoices"].Rows[i]["Amount"] > ds.Tables["Invoices"].Rows[i - 1]["Amount"])
           {}
        }
        if( i < ds.Tables["Invoices"].Rows.Count - 1 )
        {
            if( ds.Tables["Invoices"].Rows[i]["Amount"] > ds.Tables["Invoices"].Rows[i + 1]["Amount"])
            {}
        }
    }
