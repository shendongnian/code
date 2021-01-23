    List<base> list = getFilters();
    foreach(Base filter in list)
    {
       if(filter is DerivedFilter1)
       {
          var derived1 = filter as DerivedFilter1;  
          // do some DerivedFilter1 specific operations
       }
       else if(filter is DerivedFilter2)
       {
          var derived2 = filter as DerivedFilter2;  
          // do some DerivedFilter2 specific operations
       }
       else 
       {
          // do some general operations
       }
    }
