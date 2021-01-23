    public class ReadData
    {
        public bool FindString(string myString)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=..."; //Your connection string
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "FindString";
            command.Parameters.AddWithValue("@MyString", myString);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }                
            return false;
        }
    }
