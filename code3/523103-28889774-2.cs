    try
    {
        connw.Open();
        OleDbCommand command;
        command = new OleDbCommand(
            "Update Deliveries " +
            "SET Deliveries.EmployeeID = ?, Deliveries.FIN = ?, Deliveries.TodaysOrders = ? , connw);
        command.Parameters.Add(new OleDbParameter("@EMPID", Convert.ToDecimal(empsplitIt[1])));
        command.Parameters.Add(new OleDbParameter("@FIN", truckSplit[1].ToString()));
        command.Parameters.Add(new OleDbParameter("@TodaysOrder", "R"));
        catchReturnedRows = command.ExecuteNonQuery();//Commit   
        connw.Close();
    }
    catch (OleDbException exception)
    {
        MessageBox.Show(exception.Message, "OleDb Exception");
    }
