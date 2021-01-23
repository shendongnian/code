    class Base {
      public int First;
    }
    
    class Derived {
      public int Last;
    }
    
    var me = Base{ First = "Alexei" };
    var someone = Derived { First = "Alexei", Last = "Unknown" };
