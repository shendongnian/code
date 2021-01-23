        AdoHelper.ConnectionString = "...";
        using (AdoHelper db = new AdoHelper())
        {
            // Start the transaction
            db.BeginTransaction();
            try
            {
                db.ExecNonQuery("UPDATE FeedItems SET Title = 'Test3' WHERE Id = 456");
                db.ExecNonQuery("UPDATE FeedItems SET Title = 'Test4' WHERE Id = 457");
                // Commit  
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
            }
        }
