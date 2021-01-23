    public void ProcessRequest(HttpContext context)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=ESLHP280G1P\\SQLEXPRESS; Database=Sample; user id=sa; password=sa@123";
                connection.Open();
                SqlCommand cmd = new SqlCommand("tblImage_Retrieve", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", context.Request.QueryString["id"]);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    byte[] bytes = (byte[])dr["photo"];
                    if (bytes.Length > 0 && bytes != null)
                    {
                        context.Response.ContentType = "jpg";
                        context.Response.BinaryWrite(bytes);
                    }
                }
            }
        }
