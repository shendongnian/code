    public class ConsistentGuaranteedComparer : IEqualityComparer<string>
    {
      public bool Equals(string x, string y)
      {
        return x == y;
      }
      public int GetHashCode(string obj)
      {
        if(obj == null)
          return 0;
        int hash = obj.Length;
        for(int i = 0; i != obj.Length; ++i)
          // creating hash code
          hash = (hash << 5) - hash + obj[i];
        return hash;
      }
    }
