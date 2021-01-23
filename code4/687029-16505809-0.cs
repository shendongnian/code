    using(SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=rex;Initial Catalog=Project DB 1;Integrated Security=True"))
    {
        con.Open();
        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
        {
            String insertData = "INSERT INTO SalesTable(CustCode,ItemCode,Date,Quantity) " + 
                                "VALUES (@CustCode,@ItemCode,@Date,@Quantity)";
            SqlCommand cmd = new SqlCommand(insertData, con);
            cmd.Parameters.AddWithValue("@CustCode", 
                           dataGridView1.Rows[i].Cells[0].Value ?? DbNull.Value);
            cmd.Parameters.AddWithValue("@ItemCode", 
                           dataGridView1.Rows[i].Cells[1].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", 
                           dataGridView1.Rows[i].Cells[2].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", 
                           dataGridView1.Rows[i].Cells[3].Value ?? DBNUll.Value);
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
    }
