    //class variable:
    DataSet ds  = new DataSet();
    
    //fill dataset in some of your method:
    using(SqlConnection conn = new SqlConnection("connString"))
    {
        DataTable table1 = new DataTable("People");
        DataTable table2 = new DataTable("Cars");
        ds.Tables.Add(table1);
        ds.Tables.Add(table2);
        string query1 = @"SELECT * FROM People";
        string query2 = @"SELECT * FROM Cars";
        string[] queries = { query1, query2 };
        for(int i = 0; i < queries.Length; i++)
        {
             using(SqlDataAdapter da = new SqlDataAdapter(queries[i], conn))
                 da.Fill(ds.Tables[i]);
        }
    }
    
    //now bind tables to your button click events (this is example for Cars):
    void button1_Click()
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = ds.Tables["Cars"].DefaultView; 
    
        //do the same for table "People" in some other button click event
    }
