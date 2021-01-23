    public static bool command(string input, MySqlConnection con)
    {
        try
        {
        MySqlCommand command = new MySqlCommand(input, con);
        var resultSet = command.ExecuteNonQuery();
        if (!resultSet.Equals(0))
            return true;
        return false;
        }
        catch
        {}
        return false;
    }
