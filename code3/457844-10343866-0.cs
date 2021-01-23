    var args = System.Web.UI.DataSourceSelectArguments.Empty;
    var reader = (SqlDataReader) UserDetailsSqlDataSource.Select(args);
    
    while(reader.Read()) {
       //do something with each returned record, e.g.
       MailMessage mail = new MailMessage();
       mail.To.Add(reader["LoweredEmail"].ToString());
    }
 
