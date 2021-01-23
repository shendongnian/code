    static string connString = "Data Source=localhost; Initial Catalog=project; Integrated Security=True";
    public static int InsertImage(byte[] imgdata)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Images(ImageData) OUTPUT inserted.ID VALUES(@p1)", conn))
            {
                cmd.Parameters.AddWithValue("@p1", imgdata);
                int res = (int)cmd.ExecuteScalar()
                return res;
            }
        }
    }
