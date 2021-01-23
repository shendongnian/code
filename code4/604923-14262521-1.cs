    using (OleDbConnection conn = new OleDbConnection(strCon))
    {
        String sqlPoints = "SELECT points FROM customer WHERE [customerID]=" +   txtCustomerID.Text;
        // Create a command to use to call the database.
        OleDbCommand command = new OleDbCommand(sqlPoints, conn)
        // Create a reader containing your results
        using(OleDbReader reader = command.ExecuteReader()) 
        {
            reader.Read(); // Advance to the first row.
            txtPoints.Text = reader[0].ToString(); // Read the contents of the first column
        }
    }
