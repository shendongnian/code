    public static byte[] GetImage(string ImageId)
    { byte[] img = null;
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "your_store_procedure_returns_binary_Image";
    cmd.Parameters.AddWithValue("@CODE", ImageId);
    cmd.Connection = yourConnection();
    SqlDataReader dr = null;
    dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        img = (byte[])dr[0];
    }
    dr.Close();
    return img;//returns array of byte
    }
