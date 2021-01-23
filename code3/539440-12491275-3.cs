    SqlConnection db = new SqlConnection(YourConnectionString);
    SqlCommand dbc = new SqlCommand("vts_spVoterExportCSVData", db);
    dbc.CommandType = CommandType.StoredProcedure;
    
    SqlParameter Seed = dbc.Parameters.Add("@Seed", SqlDbType.Int);
    Seed.Direction = ParameterDirection.Input;
    Seed.Value = request.form("ddlSeed");
    db.Open();
    
    SqlDataReader Results = dbc.ExecuteReader();
    
    while (Results.Read())  {
        //Results["VoterID"].ToString();
        //Results["AnswerID"].ToString();
        //Results["SectionNumber"].ToString();
        //Results["AnswerText"].ToString();
    };
    
    Results.Close();
