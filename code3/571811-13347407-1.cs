    InContext inContext = new InContext(cnStr);
    // get first biggest item
    BatchPINDetail entity = inContext.BatchDetailsRecords
                                     .OrderByDescending(x => x.Number)
                                     .First();
    // get all biggest items
    BatchPINDetail entities = inContext.BatchDetailsRecords
                                     .Where(x => x.Number == x.Max(x => x.Number))
                                     .ToArray();
    // and if you just want to get biggest number. 
    // but note that if you just change `num` nothing will happen.
    int num = inContext.BatchDetailsRecords.Max(x => x.Number);
    entity.Number += 1;
    inContext.SaveChanges();
