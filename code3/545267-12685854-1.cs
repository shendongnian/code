            ...
            try
            {
                using (txn = cnctn.BeginTransaction())
                {
                    oldMaxId = GetAndSetMaxIdTable(factory, cnctn, txn, 5);
                    for (i = 0; i < 5; i++)
                    {
                        UseNewIdToInsertStuff(factory, cnctn, txn, oldMaxId + i + 1)
                    }
                    txn.Commit();
                    return true;
                }
            }
            catch (Exception e)
            {
                // don't know if this is needed
                if (txn != null && cnctn.State == ConnectionState.Open)
                    txn.Rollback();
                throw e;
            }
  
            ...
