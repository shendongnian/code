    List<Consumer> consumers = null;
    using ( var ctx = new XXXEntities() )
    {
      consumers = ctx.Consumers.Where( ... ).ToList();
      // EF will populate consumers.Purchases when it loads these objects
      ctx.Purchases.Where( ... ).ToList();
    }
    // the Purchase objects are now in the consumer.Purchases collections
    var sum = consumers.Sum( c => c.Purchases.Sum( p => p.TotalCost ) );
