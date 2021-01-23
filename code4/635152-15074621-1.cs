    using(SqlConnection cn = new SqlConnection(constring))
    {
        cn.Open();
        SqlCommand cmd = new SqlCommand("pa_rep_mail", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
          dir_mails.Add(sdr["mail_usuario"].ToString());
        }
    }
