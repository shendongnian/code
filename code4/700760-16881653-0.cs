    string query =
        @"INSERT INTO tbl_RentFactor([ID],DateNow,customerName, objectName, 
          objectNumber,unitCost,objectCost,paidMoney,restOfMonyy,customerID,DateBack)
          VALUES (?,?,?,?,?,?,?,?,?,?,?)";
    con.Open();
    for (int i = 0; i < (dataGridFactorRent.Rows.Count) - 1; i++)
    {
        using (var command = new OleDbCommand(query, con));
        {
            command.Parameters.AddWithValue("?", ID);
            command.Parameters.AddWithValue("?", lbldate.Text);
            command.Parameters.AddWithValue("?", cmdCustomName.Text);
            command.Parameters.AddWithValue("?", dataGridFactorRent.Rows[i].Cells[1].Value);
            command.Parameters.AddWithValue("?", dataGridFactorRent.Rows[i].Cells[3].Value);
            command.Parameters.AddWithValue("?", dataGridFactorRent.Rows[i].Cells[4].Value);
            command.Parameters.AddWithValue("?", dataGridFactorRent.Rows[i].Cells[5].Value);
            command.Parameters.AddWithValue("?", txtPaid.Text);
            command.Parameters.AddWithValue("?", lblRemained.Text);
            command.Parameters.AddWithValue("?", customerID);
            command.Parameters.AddWithValue("?", lbldate.Text);
            command.ExecuteNonQuery();
        }
    }
    con.Close();
