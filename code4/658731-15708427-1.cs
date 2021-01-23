    string gameweekIDString = Request.QueryString["gameweekID"];
    int gameweekID;
    if (!int.TryParse(gameweekIDString, out gameweekID))
    {
        gameweekID = 1;
    }
