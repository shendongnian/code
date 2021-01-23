    SqlCommand cmdEvent = new SqlCommand("SELECT COUNT(date) FROM patients WHERE date= '2012/02/23'", yourSqlConnection);
    object myCount;
    if (yourSqlConnection.State == ConnectionState.Closed){ yourSqlConnection.Open(); }
    myCount = cmdEvent.ExecuteScalar();
    if (yourSqlConnection.State == ConnectionState.Open){ yourSqlConnection.Close(); }
    
    if (myCount != null)
    {
      if ((int)myCount >= 10)
      {
        // Logic here e.g myLabel.Text = "You have reached your maximum of 10 visits!";
        return;
      }
    }
