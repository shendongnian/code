    class Last3BitsComparer : IEqualityComparer<int>
    {
      public bool Equals(int b1, int b2)
      {
        return (b1 & 3) == (b2 & 3);
      }
      public int GetHashCode(int bx)
      {
        return bx & 3;
      }
    }
