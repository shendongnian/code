    using(SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=rex;Initial Catalog=Project DB 1;Integrated Security=True"))
    {
        con.Open();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if(!row.IsNewRow)
            {
                String insertData = "INSERT INTO SalesTable(CustCode,ItemCode,Date,Quantity) " + 
                                    "VALUES (@CustCode,@ItemCode,@Date,@Quantity)";
                SqlCommand cmd = new SqlCommand(insertData, con);
                cmd.Parameters.AddWithValue("@CustCode", row.Cells[0].Value ?? DbNull.Value);
                cmd.Parameters.AddWithValue("@ItemCode", row.Cells[1].Value ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Date", row.Cells[2].Value ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Quantity", row.Cells[3].Value ?? DBNUll.Value);
                cmd.ExecuteNonQuery();
            }
        }
    }
