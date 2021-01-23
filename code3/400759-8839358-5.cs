    public class RandomComparer : IEqualityComparer<string>
    {
      private int hashSeed = Environment.TickCount;
      public bool Equals(string x, string y)
      {
        return x == y;
      }
      public int GetHashCode(string obj)
      {
        return obj.SpookyHash32(hashSeed);
      }
    }
