    class FWrap<TIn, TOut> //depending on your arities
    {
      public Func<TIn, TOut> Fnc {get; set;} 
      public Category Cat {get; set;}
      //some constructor and stuff
    }
