    using (OleDbConnection conn = new OleDbConnection(strCon))
    {
        String sqlPoints = "SELECT points FROM customer WHERE [customerID]=" +   txtCustomerID.Text;
    
        using(OleDbCommand command = new OleDbCommand(sqlPoints, conn)) 
        {
            reader.Read(); // Advance to the first row.
            txtPoints.Text = reader[0].ToString(); // Read the contents of the first column
        }
    }
