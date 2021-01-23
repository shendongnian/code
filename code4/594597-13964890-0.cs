    private void InsertPlatypiRequestedRecord(string platypusId, string platypusName, DateTime invitationSentLocal)
    {
        using (var db = new SQLiteConnection(SQLitePath))
        {
            db.CreateTable<PlatypiRequested>();
            db.RunInTransaction(() =>
            {
                db.Insert(new PlatypiRequested
                {
                    PlatypusId = platypusId,
                    PlatypusName = platypusName,
                    InvitationSentLocal = invitationSentLocal
                });
            });
        }
    }
