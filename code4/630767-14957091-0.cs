    UnitOfWork _context = new UnitOfWork();
    
    // Add 1
    _context.Add(obj);
    
    using(UnitOfWork context = new UnitOfWork()){
       // Do second addition routines here based on objects used in add 1.
       context.Add(childobj);
       context.SaveChanges();
    }
    
    _context.SaveChanges();
