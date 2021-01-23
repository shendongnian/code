    private string GetSqlDataSourceID(object sender)
    {
        return (sender.GetType().GetField("_owner", BindingFlags.NonPublic | 
              BindingFlags.Instance).GetValue(sender) as SqlDataSource).ID;
    }
