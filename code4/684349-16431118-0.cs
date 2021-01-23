    public struct Cell
    {
       [...]
       public override int GetHashCode()
       {
           return Row.GetHashCode() ^ Col.GetHashCode();
       }
    }
