    public DbSet<IxDetails> IxDetailRecords { get; set; }
    IxContext ixContext = new IxContext();
    for (int k = 0; k < 100; k++)
    {
           IxDetails ix = ixContext.IxDetailRecords.Create();
           ix.EnteredBy = "";// current user;
           ix.EntryDate = DateTime.Now;
           ix.FacilityID = facility;
           ix.FirstName = "";
           ixContext.IxDetailRecords.Add(ix);
     }
     ixContext.SaveChanges();
