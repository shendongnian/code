    if (!IsPostBack)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["RaiseFantasyLeagueConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("[dbo].[GetUsersProfile]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        SqlParameter userIDParam = new SqlParameter("@userId", userId);
        cmd.Parameters.Add(userIDParam);
        conn.Open();
        SqlDataReader dReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (dReader.Read())
        {
            FirstName.Text = (dReader["ManagerFirstName"].ToString());
            Surname.Text = (dReader["ManagerSurname"].ToString());
            TeamName.Text = (dReader["TeamName"].ToString());
            StadiumName.Text = (dReader["TeamStadium"].ToString());
            Email.Text = (dReader["Email"].ToString());
            Reminder.Checked = (bool)dReader["RecieveReminder"];
            Prediction.Checked = (bool)dReader["RecieveSummary"];
        }
        dReader.Close();
        conn.Close();
    }
    
