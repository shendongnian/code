    using (ITransaction transaction = Session.BeginTransaction())
         {
            try
            {
               Entry entry = Session.Load<Entry>(message.EntryId);
               Comment comment = SaveComment(entry, new BroadcastMetadata { some data });
               transaction.Commit();
            }
         }
    
         // i access the entry.LatestBroadcast info here but my entry doesnt have the new comment assigned yet !
         var latestData = entry.LatestBroadcast; // is null
