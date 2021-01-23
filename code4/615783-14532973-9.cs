    ApiData apiData = DeserializeMyApiData(); // from above
    array[0][0] = apiData.Status;
    for(int i = 1; i <= apiData.Sessions.Count; i++)
    {
        var session = apiData.Sessions[i - 1];
        array[i] = new object[8];
        array[i][0] = session.ID;
        array[i][1] = session.SessionID;
        array[i][2] = session.GameID;
        array[i][3] = session.MaxPlayers;
        array[i][4] = session.HostIP;
        array[i][5] = session.HostPort;
        array[i][6] = session.InProgress;
        array[i][7] = session.TimeStamp;
    }
