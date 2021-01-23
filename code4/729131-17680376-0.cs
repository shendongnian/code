    public class ExcelCellIdentifier : IEquatable<ExcelCellIdentifier>
    {
       public ExcelCellIdentifier(string ticker, string identifier)
       {
            Ticker = ticker;
            Identifier = identifier;
       }
    
       public override bool Equals(object obj)
       {
          var identifier = obj as ExcelCellIdentifier;
          if(identifier == null)
              return false;
          else
              return Equals(identifier);
       }
    
       public override int GetHashCode()
       {
          unchecked
          {
              int hash = 17;
              hash = hash * 23 + Ticker.GetHashCode();
              hash =  hash * 23 + Identifier.GetHashCode();
              return hash;
          }
       }
       public string Ticker { get; set; } //This should likely be changed to {get; private set;}
       public string Identifier { get; set; } //This should likely be changed to {get; private set;}
    
       public bool Equals(ExcelCellIdentifier other)
       {
          return Ticker.Equals(other.Ticker) && Equals(other.Identifier);
       }
    }
