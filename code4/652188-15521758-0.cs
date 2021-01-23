    DataTable transactions = getAllTransactions();
    List<TransactionModel> model = new List<TransactionModel>();
    foreach (DataRow transaction in transactions.Rows)
    {
        TransactionModel tran = new TransactionModel
                                {
                                    transId = transaction.Field<int>("transID"),
                                    clientId = transaction.Field<int>("clientId"),
                                    clientName = transaction.Field<string>("ClientName")
                                    //etc...
                                };
        model.Add(tran);
    }
