    public Form1()
    {
        ds = new DataSet();
        // 1. Create connection.
        conn = new OleDbConnection(@"connection_string.");
        // 2. init SqlDataAdapter with select command and connection
        da = new OleDbDataAdapter("Select * from YouRtable", conn);
    
        // 3. fill in insert, update, and delete commands 
           (For No. 3 - You can search around the internet on how to construct a SQL Command). You can refer the values that you to insert from the textboxes that you have.)
    
        OleDbCommandBuilder cmdBldr = new OleDbCommandBuilder(da);
        da.Fill(ds, "YouRtable");
        dataGridView2.DataSource = ds;
        dataGridView2.DataMember = "YouRtable";
    }
    
    //Here is your save/update button code.
    private void btnSaveGridData_Click(object sender, EventArgs e)
    {
        da.Update(ds, "YouRtable");
    }
