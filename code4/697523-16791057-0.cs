    [WebMethod]
        public void ExecuteSql(string query)
        {
           SqlCommand cmd  = new SqlCommand();
           cmd.Connection = new SqlConnection("connectionstring");
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = query;
           cmd.Connection.Open();
           cmd.ExecuteScalar();
           cmd.Connection.Close();
        }
