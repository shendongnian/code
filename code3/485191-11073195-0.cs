    // Assuming DB1 is your object context
    Record obj = DB1.Records.Where(x => x.ID == o.ID).OrderByDescending(x => x.Idx).First();
    
    ...
    
    DB1.Detach(obj); // <------ Detaches from context, removes from memory
