    DataSet ds = new DataSet();
    ds = DB.ExecuteQuery_SP("getAllSeenUuids");
    List<string> uuids = pop3Client.GetMessageUids();
    List<string> listSeenUuids = new List<string>();
    List<string> newListSeenUuids = new List<string>();
    List<Message> newMessages = new List<Message>();
    List<string> listUnreadUuids = new List<string>();
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        listSeenUuids.Add(ds.Tables[0].Rows[i][0].ToString());
    }
    for (int i = uuids.Count - 1; i >= 0; i--)
    {
        if (!listSeenUuids.Contains(uuids[i]))
        {
            Message unseenMessage = pop3Client.GetMessage(i + 1);
            newMessages.Add(unseenMessage);
            object[,] parArray = new object[,] { { "@seenUuid", uuids[i] } };
            //Call Stored Procedure_SP("saveToSeenUuids", parArray);
         }
    }
