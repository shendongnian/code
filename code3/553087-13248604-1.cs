    try
    {
        using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
        {
            MegaBotExtractorDBContext2 db = new MegaBotExtractorDBContext2();
            MegaBotExtractorDBContext db1 = new MegaBotExtractorDBContext();
            FullUri newUri = new FullUri();
            HostUri NewHostUri = new HostUri { HostUriName = "google10.com" };
            db1.HostUris.Add(NewHostUri);
            db1.SaveChanges();
            using (TransactionScope ts2 = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                db.FullUris.Add(newUri);
                db.SaveChanges();
                ts2.Complete();
                ts.Complete();
            }
        }
    }
    catch { }
