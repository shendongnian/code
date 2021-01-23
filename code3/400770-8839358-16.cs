    public class RandomComparer : IEqualityComparer<string>
    {
      private long seed0 = Environment.TickCount;
      private long seed1 = DateTime.Now.Ticks;
      public bool Equals(string x, string y)
      {
        return x == y;
      }
      public int GetHashCode(string obj)
      {
        return obj.SpookyHash128(seed0, seed1).GetHashCode();
      }
    }
