    public bool DeleteUser(int userId)
    {
        string connString = "your connectionstring";
        try
        {
          using (var conn = new SqlConnection(connString))
          {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM tbl_Users WHERE userID = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
          }
        }
        catch(Exception ex)
        {
          //Log the Error here for Debugging
          return false;
        }
    
    }
