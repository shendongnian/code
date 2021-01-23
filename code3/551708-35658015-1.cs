            var batch = db.Set<SomeListToIterate>().ToList();
            var exceptions = batch.Parallel((item) =>
            {
                using (var batchDb = db.CreateInstance())
                {
                    var batchTime = batchDb.GetDBTime();
                    var someData = batchDb.Set<Permission>().Where(x=>x.ID = item.ID).ToList();
                    //do stuff to someData
                    item.WasMigrated = true; //note that this record is attached to db not batchDb and will only be saved when db.SaveChanges() is called
                    batchDb.SaveChanges();        
                }                
            });
            if (exceptions.Count > 0)
            {
                logger.Error("ContactRecordMigration : Content: Error processing one or more records", new AggregateException(exceptions));
                throw new AggregateException(exceptions); //optionally throw an exception
            }
            db.SaveChanges(); //save the item modifications
