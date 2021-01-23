    public class ExcelCellIdentifier : IEquatable<ExcelCellIdentifier>
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
       #region IEquatable<ExcelCellIdentifier> Members
       public bool Equals(ExcelCellIdentifier other)
       {
          return Ticker.Equals(other.Ticker) &&
              Identifier.Equals(other.Identifier);
       }
       public int GetHashCode(ExcelCellIdentifier obj)
       {
          return obj.Ticker.GetHashCode() ^ 
              obj.Identifier.GetHashCode();
       }
       #endregion
