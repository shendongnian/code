    Int64 ret = 0;
    
    using (var transaction = new TransactionScope(TransactionScopeOption.Required))
    {
        try
        {
            using (var context = new MyContext())
            {
                var secondaryEntity = new HOTEL();
                primaryEntity.HOTEL = secondaryEntity;
                context.HOTELs.Add(secondaryEntity);
                context.OWNERs.Attach(primaryEntity);
                context.Entry(primaryEntity).State = primaryEntity.OWNER_ID == 0 ? EntityState.Added : EntityState.Modified;
    
                context.SaveChanges();
                ret = primaryEntity.OWNER_ID;
                // TransactionScopeOption.Required can still used in case something 
                // goes wrong with additional processing at this point.
    
                if (ret != 0)
                {
                    transaction.Complete();
                }
            }
        }
        catch (Exception ex)
        {
            // Deal with errors.
        }
    }
    return ret;
