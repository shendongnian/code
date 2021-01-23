    public override bool Equals(object obj)
    {
      if (!(obj is bool))
        return false;
      else
        return this == (bool) obj;
    }
    public bool Equals(bool obj)
    {
      return this == obj;
    }
