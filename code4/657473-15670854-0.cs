    using (var ctx = new DataModel(_connectionString))
    {
        bool saved = false;
        do
        {
            var MyObject it = ctx.MyObjects.Where(someConstraint).ToList()[0];
            try
            {
                it.TimeProperty= DateTime.UtcNow; //Setting the field
                ctx.SaveChanges(SaveOptions.AcceptAllChangesAfterSave); 
                saved = true;
            }
            catch (OptimisticConcurrencyException)
            {
                _logger.DebugFormat(workerClassName + ": another worker just updated the LastCheckTime");
    
                ctx.Refresh(RefreshMode.StoreWins, it);
                ctx.AcceptAllChanges();
           }
        } while( !saved )
        //Do some other work and/or sleep
    }
