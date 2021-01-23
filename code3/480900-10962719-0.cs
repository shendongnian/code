    List<Consumer> consumers = null;
    using ( var db = new XXXEntities() )
    {
      consumers = db.Consumers.Where( ... ).ToList();
      // EF will populate consumers.Purchases when it loads these objects
      db.Purchases.Where( ... ).ToList();
    }
    // the Purchase objects are now in the consumer.Purchases collections
    var sum = consumers.Sum( c => c.Purchases.Sum( p => p.TotalCost ) );
    
