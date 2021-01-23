    SQLConnection con = (your connection);
    SQLDataAdapter = sda;
    SQLCommandBuilder = scb;
    DataTable = dt;
    private void btnEnter_Click(object sender, EventArgs e)
   
    da = new SqlDataAdapter("SELECT * FROM [table] WHERE [columnA]='" + txtData.Text + "' OR [columnB]='" + txtData.Text + "' OR [ColumnC]='" + txtData.Text + "' OR [ColumnD]='" + txtData.Text + "'", con);
                ds = new DataSet();
                dt = new DataTable();
                ds.Clear();
                da.Fill(dt);
                dg.DataSource = dt;
                con.Open();
                con.Close();
    
    private void btnUpdate_Click(object sender, EventArgs e)
        {
            //when button is clicked, the SQL Database gets updated with the data that is plugged into the datagridview.
            scb = new SqlCommandBuilder(da);
            da.Update(dt);
            
        }
