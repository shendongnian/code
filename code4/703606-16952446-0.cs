    private ImmutableList<string> users = ImmutableList<string>.Empty;
    private void ParseIRCMessage(string msg)
    {
        if (msgType == "JOIN")
        {
            users = users.Add(user);
        }
        else if (msgType == "PART")
        {
            users = users.Remove(user);
        }
    }
    private void HandOutCurrency()
    {
        foreach (String user in users)
        {
            database.AddCurrency(user, 1);
        }
    }
