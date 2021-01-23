    String query="Your query to dispplay columns from the database";
    SqlCommand cmd=new SqlCommand(query,con); //con is your Connection String
    con.Open();
    DataTable dt=new DataTable();
    SqlDataAdapter da=new SqlDataAdapter(cmd);
    da.Fill(dt); //Now this DataTable is having all the columns lets say
    /* Now take another temporary DataTable to display only particular columns*/
    DataTable tempDT=new DataTable();
    tempDT=dt.DefaultView.ToTable(true,"Your column name","your column name");
    //Now bind this to DataGridView
    grid.DataSource=tempDT;
    con.Close();
