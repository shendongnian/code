    con.Open();
    com.CommandText = "SELECT * FROM Orders WHERE OrderNo="+Convert.ToInt32(txtStudNo.Text)+"";
    reader = com.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            int indx = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[indx];
            
            com2.CommandText = "SELECT Description, Price FROM Books WHERE BookID='" + reader[2].ToString() + "'";
            reader2 = com2.ExecuteReader();
            
            if (reader2.Read())
            {
                row.Cells[0].Value = reader[2].ToString();
                row.Cells[1].Value = reader2[0].ToString();
                row.Cells[2].Value = reader[4].ToString();
                row.Cells[3].Value = reader2[1].ToString();
            }
        }
    }
