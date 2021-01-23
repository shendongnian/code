    class Bint
    {
      int num;
      public bool this[int num]
      {
        get {return num << n & 0x1 == 1;}
      }
      public int Num
      {
        get {return num;}
        set {num = value;}
      }
    }
