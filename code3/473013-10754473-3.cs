    DataTable dt = new DataTable("Table1");
    DataTable dt2 = new DataTable("Table2");
    
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    ds.Tables.Add(dt2);
    
    //Now you can access these as:
    
    if(b==1)
        {
        dataGridView1.DataSource = ds.Tables["Table1"];
        }
        else if(b==2)
        {
        dataGridView1.DataSource = ds.Tables["Table2"];
        }
