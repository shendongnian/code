    objectContext = ((IObjectContextAdapter)entities).ObjectContext;
    try{
        objectContext.Connection.Open();
        using (var tran = new TransactionScope()) {
            table1 obj1 = new table1
            {
                AccountHolderName = model.AccountHolderName,
                AccountNumber = model.AccountNumber,
                Address = model.Address,
            };
            entities.table1.Add(obj1);
            entities.SaveChanges();
            table2 obj = new table2
            {
                ID = model.ID == 1 ? id : model.ID,
                Username = model.Email,
                Password = model.Password,
            };
            entities.table2.Add(obj2);
            entities.SaveChanges();
            tran.Complete();
        }
    }
    finally{
        objectContext.Connection.Close();
    }
