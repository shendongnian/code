    [WebMethod]
    public string GetEmps(DateTime inputDate)
    {
        // create a parameterized query
        string getdays = "Select Emp from WorkingDaysinfo Where date = @inputDate";
        con = new MySqlConnection(conString);
        con.Open();
        MySqlCommand cmd = new MySqlCommand(getdays, con);
        // pass the parameter value 
        cmd.Parameters.Add(new SqlParameter("inputDate", inputDate);
        
        // rest of the code follows
        ..
