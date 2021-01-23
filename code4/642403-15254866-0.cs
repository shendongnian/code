    class MyEntity{
      public virtual decimal Amount { get; set; }
    
      public virtual decimal DivideOfThisAmountOnAll(YourDbContext db)
      {  
            var sum = db.LinqQueryHereToAggregateAsYouPlease.Single();
            return this.Amount / sum;
      }
    
    }
