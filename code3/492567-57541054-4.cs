    public static bool IsNullOrWhiteSpace(this string x)
    {
        return string.IsNullOrWhiteSpace(x);
    }
    public static DataTable GetDataTable(string Query)
    {
        MySqlConnection connection = new MySqlConnection("<Connection_String>");
        try
        {            
            DataTable data = new DataTable();
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(Query, connection))
            {
                data.Load(command.ExecuteReader());
            }
            return data;
        }
        catch (Exception ex)
        {
            // handle exception here
            Console.WriteLine(ex);
            throw ex;
        }
        finally
        {
            connection.Close();
        }            
    }
