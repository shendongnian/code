    StringBuilder queryPart = new StringBuilder("");
    foreach (int id in transactionsToUpdate.ToList())
    {
    queryPart.Append("TransactionID=");
    queryPart.Append(id);
    queryPart.Append(" OR ");
    }
    queryPart.Append("1=0");
    string query = @"UPDATE dbo.OutgoingQueue SET Status='C' WHERE "+queryPart.toString();
