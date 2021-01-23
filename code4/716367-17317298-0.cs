    using(var outer = new AnotherDisposable())
    {
       using(var inner = new MyDisposable(outer))
       {
          //whatever
       }
        
    }
