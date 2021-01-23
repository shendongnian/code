    int count = 0;
    int bulkCount = 1000;
    while (count < transactionsToUpdate.Count)
    {
        string queryPart = String.Join(",", transactionsToUpdate.ToArray().Skip(count).Take(bulkCount));
        string query = @"UPDATE dbo.OutgoingQueue SET Status='C' WHERE TransactionID IN(" + queryPart + ")";
        //execute the sql here by doing the ExecuteNonQuery call.
        count += bulkCount;
    }
