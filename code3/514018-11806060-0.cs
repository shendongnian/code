    string conncetionStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
    SqlConnection msSQLConnectoin = new SqlConnection(conncetionStr);
    SqlCommand msSQLCommand = msSQLConnectoin.CreateCommand();
    msSQLCommand.CommandText = "app_Event_Type_Select";
    msSQLConnectoin.Open();
    SqlDataReader msDataReader = msSQLCommand.ExecuteReader();
    while (msDataReader.Read())
    {
        dropDown.DataSource = msDataReader; 
        dropDown.DataTextField = "Name";
        dropDown.DataValueField = "EventTypeID"; 
        dropDown.DataBind();
    }
