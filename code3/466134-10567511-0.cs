    public override int GetHashCode()
    {
      int hc = 0;
      if (Paths != null)
        foreach (var p in Paths)
          hc ^= p.GetHashCode();
      return hc;
    }
