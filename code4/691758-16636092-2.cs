    if( myConnection == null )
    {
        string connectionString = string.Format( "user id={0}, password={1}", userIdTextBox.Text, passwordTextBox.Text );
      myConnection = new SqlConnection( connectionString );
    }
