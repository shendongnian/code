    internal DataTable ConnectedSelect(string TableName, string[] Cols, string Condition)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(GenerateSelectStatment(TableName, Cols, Condition),con))
            {
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows)
                   dt.Load(rdr);
            }
        }
        return dt;
    }
    }
