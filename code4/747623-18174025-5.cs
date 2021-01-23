      try {  
        c = a / b;
      }  
      catch (DivideByZeroException) {
        c = Int.MaxValue; // <- in case b = 0, let c be the maximum possible int
      }
