    class SumObject { 
      public float First; 
      public float Second; 
    }
    var filtered = (from m in month
         where <some long expression>
         select m;
    filtered.Aggregate(new SumObject(), (currentSum, item)=> { 
      currentSum.First += item.First;  
      currentSum.Second += item.Second;
      return currentSum;
    });
