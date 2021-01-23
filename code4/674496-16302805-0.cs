        private void getAuditChecklist()
    {
    SqlCommand cmd = null;
    string conn =    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string queryString = @"SELECT Mount, Braker, Access, Conn_Net, Log_Book, Pictures, Floor, Cb_Lenght, Channel FROM AUDITOR_CHECKLIST " +
        "WHERE SITE_ID = @SiteID";        
    using (SqlConnection connection =
               new SqlConnection(conn))
    {
        SqlCommand command =
            new SqlCommand(queryString, connection);
        connection.Open();
        cmd = new SqlCommand(queryString);
        cmd.Connection = connection;
        cmd.Parameters.Add(new SqlParameter("@SiteID", //the name of the parameter to map
              System.Data.SqlDbType.NVarChar, //SqlDbType value
              20, //The width of the parameter
              "SITE_ID")); //The name of the column source
        //Fill the parameter with the value retrieved
        //from the text field
        cmd.Parameters["@SiteID"].Value = foo.Site_ID;
        SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
     {                    
    CheckBox1.Checked = (reader.GetBoolean(reader.GetOrdinal("Mount")));
    CheckBox2.Checked = (reader.GetBoolean(reader.GetOrdinal("Braker")));
    CheckBox3.Checked = (reader.GetBoolean(reader.GetOrdinal("Access")));
    CheckBox4.Checked = (reader.GetBoolean(reader.GetOrdinal("Conn_Net")));
    CheckBox5.Checked = (reader.GetBoolean(reader.GetOrdinal("Log_Book")));
    CheckBox6.Checked = (reader.GetBoolean(reader.GetOrdinal("Pictures")));
    CheckBox8.Checked = (reader.GetBoolean(reader.GetOrdinal("Floor")));
    CheckBox9.Checked = (reader.GetBoolean(reader.GetOrdinal("Cb_lenght")));
    CheckBox10.Checked = (reader.GetBoolean(reader.GetOrdinal("Channel")));
     } 
    reader.Close();
     }        
    }
