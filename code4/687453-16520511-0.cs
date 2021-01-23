    public object[][] SendOnlineContacts()
    {
        //...
        for (int i = 0; i < FriendsDt.Rows.Count; i++)
        {
            int FriendID = Convert.ToInt16(FriendsDt.Rows[i][0]);
            DataRow[] FriendisOnlineRow = ConnectedClientDt.Select("ClientID=" + FriendID);
            if (FriendisOnlineRow.Length > 0)  // friend is online 
            {
                //  new SQLHelper(SQLHelper.ConnectionStrings.WebSiteConnectionString).Update("Update clients set USER_STATUS='O' where CLIENT_ID=" + FriendsDt.Rows[i][0]);
                FriendsInfo.Rows.Add(FriendsDt.Rows[i][0] + "," + FriendsDt.Rows[i][1] + "," + FriendsDt.Rows[i][2] + "," + "O");
            }
        }
        var rows = FriendsInfo.Rows
            .OfType<DataRow>()
            .Select(row => row.ItemArray)
            .ToArray();
        return rows;
    }
