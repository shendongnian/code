    public class RandomComparer : IEqualityComparer<string>
    {
      private int hashSeed = Environment.TickCount;
      public bool Equals(string x, string y)
      {
        return x == y;
      }
      public int GetHashCode(string obj)
      {
        if(obj == null)
          return 0;
        int hash = hashSeed + obj.Length;
        for(int i = 0; i != obj.Length; ++i)
          hash = hash << 5 - hash + obj[i];
        hash += (hash <<  15) ^ 0xffffcd7d;
        hash ^= (hash >>> 10);
        hash += (hash <<   3);
        hash ^= (hash >>>  6);
        hash += (hash <<   2) + (hash << 14);
        return hash ^ (hash >>> 16)
      }
    }
