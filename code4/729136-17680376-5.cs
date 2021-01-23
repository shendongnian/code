       public override int GetHashCode()
       {
          //All this below is a common performance thing I add, if you have the two strings "Foo" and "Bar" it will give you a different hash code than the string "Bar" and "Foo", it gives you a better distribution of the hash.
          unchecked
          {
              int hash = 17;
              hash = hash * 23 + StringComparer.OrdinalIgnoreCase.GetHashCode(Ticker);
              hash =  hash * 23 + StringComparer.OrdinalIgnoreCase.GetHashCode(Identifier);
              return hash;
          }
       }
    
       public string Ticker { get; set; } //This should likely be changed to {get; private set;}
       public string Identifier { get; set; } //This should likely be changed to {get; private set;}
    
       public bool Equals(ExcelCellIdentifier other)
       {
          return StringComparer.OrdinalIgnoreCase.Equals(Ticker, other.Ticker) && StringComparer.OrdinalIgnoreCase.Equals(Identifier, other.Identifier);
       }
