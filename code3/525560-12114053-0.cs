    DataTable dt = new DataTable();
    DataRow rw = default(DataRow);
    for (int i = 0; i < ListBox1.Items.Count; i++)
    {
        dt.Columns.Add(ListBox1.Items[i].ToString(),
                                       System.Type.GetType("System.String"));             
    }
    //Simply adding 10 rows
    //Replace this hard coded loop with your looping 
    // over your data to add rows.
    for (int j = 0; j < 10; j++)
    {
        rw = dt.NewRow();
        for (int i = 0; i < ListBox1.Items.Count; i++)
        {
            rw[ListBox1.Items[i].ToString()] = "Hello there";
        }              
        dt.Rows.Add(rw);
    }
    GridView1.DataSource = dt;
    GridView1.DataBind();
