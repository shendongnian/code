     List<TransactionModel> tModels = new List<TransactionModel>();
     foreach (var row in tblResult.Tables[0].Rows) 
     {
         tModels.Add(new TransactionModel 
                     {
                       transId = row["TransId"],
                       clientId = row["ClientId"],     
                       clientName = row["clientName"]
                     });
     }
