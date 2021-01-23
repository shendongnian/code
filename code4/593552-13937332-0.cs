    protected void lnkUpdateGuardPassword_Click(object sender, EventArgs e)
    { 
        //command = query to select all the yard codes.
        List<string> YardCodes = new List<string>();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            YardCodes.Add(reader["YardCode"].ToString());
        }
        
        var random = new Random();
        foreach (var yardcode in YardCodes)
        {
            var i = random.Next(1000, 9999);
            SqlHelper.ExecuteSqlNonQuery(@"update T2_SecurityKeyHolder set
                                   GuardPassword = @newPassword
                                   WHERE YardCode = @yardcode",
                                   "newPassword", yardcode, i); 
        }                       
    }
