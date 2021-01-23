        private bool FileExists(string imageName)
        {
            using (SqlConnection conn = new SqlConnection()) // establish connection
            {
                using (SqlCommand cmd =
                    new SqlCommand("select 1 where exists(select Id from Image where ImageName = @)", conn))
                {
                    cmd.Parameters.Add("@imagename", SqlDbType.VarChar, 50).Value = imageName;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
