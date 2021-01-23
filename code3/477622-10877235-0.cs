    When I create the DataGridView, I associate it with a DataTable and
    then immediately set the first two rows to freeze. The rows don't
    freeze. However, if I handle a button click and set the rows to freeze
    in that button click, the rows successfully freeze. How, then, do I
    freeze the rows immediately upon associating the table?
    
    Here's some code:
    
    ******************
    
    DataTable dataTable = new DataTable();
    
    // Just add a bunch of columns
    for (int i = 0; i < 15; i++)
    {
    dataTable.Columns.Add("Col" + i.ToString(), typeof
    (string));
    }
    
    // Add a bunch of rows to the DataTable, with some dummy
    values
    for (int i = 0; i < 100; i++)
    {
    DataRow row = dataTable.NewRow();
    for (int j = 0; j < 15; j++)
    {
    row["Col" + j.ToString()] = "Val" + i.ToString() +
    "-" + j.ToString();
    }
    dataTable.Rows.Add(row);
    }
    
    gridView.DataSource = dataTable;
    
    gridView.Rows[1].Frozen = true;
    This won't work. The rows are not frozen. However if I stick the
    "gridView.Rows[1].Frozen = true;" line in a button event handler, it
    works. How would I do this, then, without requiring an event trigger
    from the user?
    I see two solutions:
    
    (1) Bind the data this way:
    for (int i = 0; i < 15; i++)
    {
    DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
    c.Name = "Col" + i.ToString();
    gridView.Columns.Add(c);
    }
    gridView.Rows.Add(100);
    for (int i = 0; i < 100; i++)
    for (int j = 0; j < 15; j++)
    gridView.Rows[i].Cells[j].Value = "Val" + i.ToString() + "-" + j.ToString();
    gridView.Rows[0].Frozen = true;
    
    (2) Select frozen rows in this event:
    private void gridView_DataBindingComplete(object sender,
    DataGridViewBindingCompleteEventArgs e)
    {
    FrozeFirstRow();
    }
