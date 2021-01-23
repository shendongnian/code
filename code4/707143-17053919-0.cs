    class Dice
    {
      // These are non-static fields. They are unique to each implementation of the
      // class. (i.e. Each time you create a 'Dice', these will be "created" as well.
      private int _minNum, _maxNum;
    
      // Readonly means that we can't set _diceRand anywhere but the constructor.
      // This way, we don't accidently mess with it later in the code.
      // Per comment's suggestion, leave this as static... that way only one
      // implementation is used and you get more random results.  This means that
      // each implementation of the Dice will use the same _diceRand
      private static readonly Random _diceRand = new Random();
    
      // A constructor allows you to set the intial values.
      // You would do this to FORCE the code to set it, instead
      // of relying on the programmer to remember to set the values
      // later.
      public Dice(int min, int max)
      {
        _minNum = min;
        _maxNum = max;
      }
    
      // Properties
      public Int32 MinNum
      {
        get { return _minNum; }
        set { _minNum = value; }
      }
    
      public Int32 MaxNum
      {
        get { return _maxNum; }
        set { _maxNum = value; }
      }
    
      // Methods
      // I would make your 'rolled' look more like a method instead of a public
      // a variable.  If you have it as a variable, then each time you call it, you
      // do NOT get the next random value.  It only initializes to that... so it would
      // never change.  Using a method will have it assign a new value each time.
      public int NextRoll()
      {
        return _diceRand.Next(_minNum, _maxNum);
      }    
    }
