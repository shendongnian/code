    public class ExcelCellIdentifier : IEqualityComparer<ExcelCellIdentifier>
    {
       public ExcelCellIdentifier(string ticker, string identifier)
       {
        Ticker = ticker;
        Identifier = identifier;
       }
       public override bool Equals(object obj)
       {
          return base.Equals(obj);
        }
       public string Ticker { get; set; }
       public string Identifier { get; set; }
       #region IEqualityComparer<T> Members
       public bool Equals(ExcelCellIdentifier x, ExcelCellIdentifier y)
       {
          return x.Ticker.Equals(y.Ticker) &&
              x.Identifier.Equals(y.Identifier);
        }
       public int GetHashCode(ExcelCellIdentifier obj)
       {
          return obj.Ticker.GetHashCode() ^ 
              obj.Identifier.GetHashCode();
       }
       #endregion
