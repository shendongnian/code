    var resxValue = ""; // obviously this will be whatever the type and value that is required
    var resxKey = ""; // obviously this will be whatever the type and value that is required
    // I am assuming here that you are already programming with a `using` statement
    using (OleDbConnection c = new OleDbConnection(""))
    {
        using (OleDbCommand sComm = new OleDbCommand("UPDATE TableToBeImport SET TextDefault = @p0 WHERE ControlName = @p1", c))
        {
            sComm.Parameters.Add(new OleDbParameter("@p0", resxValue));
            sComm.Parameters.Add(new OleDbParameter("@p1", resxValue));
            // rest of your code here E.G., sComm.ExecuteNonQuery();
        }
    }
