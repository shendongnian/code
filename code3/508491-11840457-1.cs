    var loging = new Loging
                     {
                         ...initialize properties...
                         Destination = new Destination{..initialize destination..}
                     }
    context.Add(loging);
    context.SaveChanges();
