     using (StorageEntities context = new StorageEntities())
     {
     foreach(item in AllData)
            {
              //Update  
              if (Exist(datefa))
                {
                var query = ClsDataBase.Database.CustomerProductTbls.SingleOrDefault
                        (data => data.CustomerId == AllData .CustomerId );
    
                        int? LastProductTotal = query.CustomerProducTtotal;
                        query.CustomerProducTtotal = LastProductTotal + ClsInsertProduct._InsertProductNumber;
    
                    }
                    //Insert 
                    else
                    {
                        _CustomerProductTbl = new CustomerProductTbl();
                        _CustomerProductTbl.CustomerId = AllData ._CustomerId;
                        _CustomerProductTbl.CustomerProductDateFa = AllData.datefa
                        .
                        .
                        .
                        ClsDataBase.Database.AddToCustomerProductTbls(_CustomerProductTbl);
                    }
                }
            }
            ClsDataBase.Database.SaveChanges();
          }
