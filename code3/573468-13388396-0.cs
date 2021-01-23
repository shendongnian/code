    [WebMethod]
    public void MyWebMethod(string input, string clientCode)
    {
            using (SqlConnection conn = new SqlConnection(your-connection-string-here))
            using (SqlCommand cmd = new SqlCommand("dbo.ProcTRequest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Pxml", SqlDbType.Xml);
                cmd.Parameters.Add("@ClientCode", SqlDbType.VarChar, 10);
                cmd.Parameters["@Pxml"].Value = input;
                cmd.Parameters["@ClientCode"].Value = clientCode;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
    }
