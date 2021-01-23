    Dictionary<Box, String> boxes = 
       new Dictionary<Box, string>(new BoxEqualityComparer());
    class BoxEqualityComparer : IEqualityComparer<Box>
    {
      public bool Equals(Box b1, Box b2)
      {
        return b1.Height == b2.Height;
      }
      public int GetHashCode(Box bx)
      {
        return bx.Height.GetHashCode();
      }
    }
