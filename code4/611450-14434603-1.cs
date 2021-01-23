    conn.Open();
    string query = "Select name, surname, mail_ad, phone_nr from cust_details";
    OracleCommand cmd = new OracleCommand(query, conn);
    OracleDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
       var details = new CustDetails { Name = dr["name"].ToString(),
                         Surname = dr["surname"].ToString(),
                         MailAddress = dr["mail_ad"].ToString(),
                         Phone = dr["phone"].ToString() }
       this.InfoList.Add(details);
    }
    dr.Close();
    conn.Close();
