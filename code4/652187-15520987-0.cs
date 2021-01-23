    List<TransactionModel> TransactionItems = tblResult.AsEnumerable().Select(r => 
    new TransactionModel
        {
            transID  = r.Field<int>("TransactionID"),
            clientID = r.Field<int>("clientID"),
            and so on.....
        }).ToList();
    return items;
