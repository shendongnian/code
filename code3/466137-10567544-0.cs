    public override int GetHashCode()
    {
      int hc = 0;
      if (Paths != null)
        foreach (var p in Paths) {
            hc ^= p.GetHashCode();
            hc = (hc << 7) | (hc >> (32 - 7)); //rotale hc to the left to swipe over all bits
        }
      return hc;
    }
