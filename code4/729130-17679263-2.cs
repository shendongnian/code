    public class myClass
    {
      private readonly Dictionary<ExcelCellIdentifier, int> allInfoByIdentifier =
      new Dictionary<ExcelCellIdentifier, int>(new ExcelCellIdentifier());
      public void testIt()
      {
         allInfoByIdentifier.Add(new ExcelCellIdentifier("Ticker1", "Identifier1"), 4);
         ExcelCellIdentifier ex = new ExcelCellIdentifier("Ticker1", "Identifier1");
         int a = allInfoByIdentifier[ex];
      }
    }
       public class ExcelCellIdentifier : IEqualityComparer<ExcelCellIdentifier>
    {
      public ExcelCellIdentifier()
      {
         
      }
        public ExcelCellIdentifier(string ticker, string identifier)
        {
            Ticker = ticker;
            Identifier = identifier;
        }
        public string Ticker { get; set; }
        public string Identifier { get; set; }
        public bool Equals(ExcelCellIdentifier x, ExcelCellIdentifier y)
        {
           return x.Identifier == y.Identifier && 
              x.Ticker == y.Ticker;
        }
        public int GetHashCode(ExcelCellIdentifier obj)
        {
           return obj.Identifier.GetHashCode() ^ 
              obj.Ticker.GetHashCode();
        }
    }
