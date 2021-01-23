    SqlCommand cmdEvent = new SqlCommand("SELECT COUNT(date) FROM patients WHERE date= '2012/02/23'", yourSqlConnection);
    object myCount;
    if (cnx.State == ConnectionState.Closed){ cnx.Open(); }
    myCount = cmdEvent.ExecuteScalar();
    if (cnx.State == ConnectionState.Open){ cnx.Close(); }
    
    if (myCount != null)
    {
      if ((int)myCount >= 10)
      {
        // Logic here e.g myLabel.Text = "You have reached your maximum of 10 visits!";
        return;
      }
    }
