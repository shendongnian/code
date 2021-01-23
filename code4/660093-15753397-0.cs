    class SixSidedDiceRoller
    {
      private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
      private SortedDictionary<int,int> frequencyTable;
      private List<Tuple<int,int,int>> rollHistory;
      
      public int Count { get { return rollHistory.Count; } }
      
      public IEnumerable<Tuple<int , int , int>> RollHistory
      {
        get { return rollHistory.AsReadOnly(); }
      }
      
      public IEnumerable<Tuple<int,int>> FrequencyTable
      {
        get
        {
          return frequencyTable.Select(
            x => new Tuple<int,int>(x.Key,x.Value)
            ) ;
        }
      }
      
      public SixSidedDiceRoller( int numberOfDice , int numberOfSides )
      {
        
        rollHistory = new List<Tuple<int , int , int>>();
        
        // initialize the frequency table
        for ( int i = 2 ; i <= 12 ; ++i )
        {
          frequencyTable[i] = 0;
        }
        
        return;
      }
      
      public int RollDice()
      {
        int d1 = RollDie();
        int d2 = RollDie();
        int n  = d1 + d2;
        rollHistory.Add( new Tuple<int , int , int>( d1 , d2 , n ) );
        ++frequencyTable[n];
        return n;
      }
      
      private int RollDie()
      {
        byte[] octets = new byte[1];
        rng.GetBytes( octets );
        int die = 1 + ( octets[0] % 6 );
        return die;
      }
      
    }
