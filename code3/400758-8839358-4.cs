    public class ConsistentGuaranteedComparer : IEqualityComparer<string>
    {
      public bool Equals(string x, string y)
      {
        return x == y;
      }
      public int GetHashCode(string obj)
      {
        return obj.SpookyHash32();
      }
    }
