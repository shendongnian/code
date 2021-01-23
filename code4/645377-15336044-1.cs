    using (var con = new SqlConnection(ConfigurationManager.AppSettings["DBCOnn"].ToString()))
    using(var cmd = new SqlCommand("select COUNT(client_id) from tbl_client where client_name=@cname", con))
    {
        cmd.Parameters.Add("@cname", DbType.String).Value = usernm;
        con.Open();
        int i = (int)cmd.ExecuteScalar();
        return i > 0;
    }
