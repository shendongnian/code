    public int saveImages(Guid ImageId, String url, byte[] imageData)
        {
          using (SqlCommand command = new SqlCommand() {
            Connection = your connection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "your Stored Procedure"
          })
          {
            try
            {
              command.Parameters.AddWithValue(...); // Add your Parameters here
              return (int)command.ExecuteScalar();
            }
            catch
            {
              return 0;
            }
          }
        }
