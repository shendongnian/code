    public static bool IsHoliday(this DateTime date)
    {
    ConnectionStringSettings myConnectionString = ConfigurationManager.ConnectionStrings["System.Properties.Settings.ConnectionString"];
    SqlConnection mySqlConnection = new SqlConnection(myConnectionString.ConnectionString);
    mySqlConnection.Open();
    SqlCommand mySqlCommand = new SqlCommand("SELECT Date FROM Holiday", mySqlConnection);
    SqlDataReader sqlreader = mySqlCommand.ExecuteReader();
    List<DateTime> holidays = new List<DateTime>();
    while (sqlreader.Read())
    {
    holidays.Add(sqlreader.GetDateTime(0));
    }
    holidays.ToArray();
    mySqlConnection.Close();
    return holidays.Contains(date.Date);
    }
