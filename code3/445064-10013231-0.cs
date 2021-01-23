    class WDay{
    
      public Monday mon = new Monday();
      public Tuesday tue = new Tuesday();
      public Wednesday wed = new Wednesday();
    
    }
    
    class Monday
    {
      private string _TempHi;
      public TempHi
      {
        get {
         return _TempHi;
        }
        set {
         _TempHi = value;
        }
      }
    }
    
    class main
    {
      WDay WeekDay = new WDay();
    
      WeekDay.mon.TempHi = "65F";
    }
