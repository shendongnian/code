    public void insertContract(contract con)
    {
        //Open
        openConnection();
        //Command
        SqlCommand myCommand = new SqlCommand("INSERT INTO tblContracts (EmployeeId,   Duration) VALUES (@employeeId, @contractDuration)", myConnection);
        //Get values from form
        formConnection formInput = new formConnection();
        //Add parameters
        myCommand.Parameters.AddWithValue("@employeeId", con.employeeId);
        myCommand.Parameters.AddWithValue("@contractDuration", con.duration);
        //Execute
        myCommand.ExecuteNonQuery();
        //Close
        closeConnection();
    }
