    private DataTable FetchData(string categoryValue)
    {
       string query = "SELECT [Key], [Value] FROM [data_LookupValues] where Category = @Category";
       using (SqlConnection con = new SqlConnection(strConn))
       using (SqlCommand cmd = new SqlCommand(query, con))
       {
           cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = categoryValue;
           SqlDataAdapter myda = new SqlDataAdapter(cmd);
           DataTable result = new DataTable();
           myda.Fill(result);
           return result;
        }
    }
