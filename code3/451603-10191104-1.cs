    string query = @"SELECT * FROM   hint  WHERE  addedSessionId IN (";
    MySqlCommand cmd = new MySqlCommand(query, _connSource);
    int i = 0;
    foreach (List<Guid> myGuid in lstGuid)
    {
        query = string.Format("{0}@param{1}", query, i);
        cmd.Parameters.AddWithValue(string.Format("@param{0}", i), myGuid.ToByteArray());
        i++;
        if(i != lstGuid.Count) query = string.Format("{0},", query);
    }
    query = string.Format("{0})", query);
    cmd.CommandText = query;
    //Here you have command with constructed query and params
