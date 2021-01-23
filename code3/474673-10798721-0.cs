    public static bool command(string input, MySqlConnection con, int expectedRowsAffected = 0)
    {
    try
    {
        MySqlCommand command = new MySqlCommand(input, con);
        var resultSet = command.ExecuteNonQuery();
        if (resultSet.Equals(expectedRowsAffected))
        {
            return true;
        }
        Console.WriteLine(string.Format("Returning false because resultSet isn't {0}", expectedRowsAffected));
        return false;
    }
    catch (Exception ex) 
	{ 
		Console.WriteLine("MySQL command error : "+ex.Message); 
	}
    Console.WriteLine("Returning false after exception");
    return false;
