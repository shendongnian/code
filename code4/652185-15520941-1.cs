    var tranModel = from r in tblResult.Tables[0]
                    select new TransactionModel 
                    {
                       transId = r.Field<int>("transID"),
                       clientId = r.Field<int>("clientId"),
                       clientName = r.Field<string>("ClientName")
                    }
