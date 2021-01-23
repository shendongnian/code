    var username = textboxUsername.Text;
    var password = textboxPassword.Text;
    
    var connectionString = string.Format(ConfigurationManager.ConnectionStrings["MyApplication"].ConnectionString, username, password)
    // at this point you have a connection string whitch could be passed to your Products class
