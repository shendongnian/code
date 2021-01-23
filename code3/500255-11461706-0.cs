       get
       {
          // Code here to call the base preset and then use it as the 
          // base of my SubClass instance.
           Base baseInstance = Base.StaticPreSet;
           SubClass sc = new SubClass(baseInstance); // Create a new instance from your base class
           return sc;
       }
    }
