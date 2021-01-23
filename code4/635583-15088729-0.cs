    // fill the dt DataTable from the database
    System.Data.DataTable dt = new System.Data.DataTable();
    // just some test data
    int columns = 3;
    int rows = 3;
    for (int i = 0; i < columns; i++)
    {
        dt.Columns.Add();
    }
    for (int i = 0; i < rows; i++)
    {
        dt.Rows.Add(new object[columns]);
    }
    // replace the placeholder with the table
    for (int w = 1; w <= doc.Words.Count; w++)
    {
        // check for the placeholder match
        if (doc.Words[w].Text == "PlaceHolder1")
        {
            Table t = doc.Tables.Add(doc.Words[w], dt.Rows.Count, dt.Columns.Count);
            for (int i = 1; i <= t.Rows.Count; i++)
            {
                for (int j = 1; j <= t.Columns.Count; j++)
                {
                    // add the 
                    t.Cell(i, j).Range.Text = String.Format("PlaceHolder1 row:{0} column: {1}", i, j);
                }
            }
        
