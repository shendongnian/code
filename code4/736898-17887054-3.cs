    public static bool operator ==(Foo x, Foo y)
    {
        return MyEquality(x, y);
    }
    public static bool operator !=(Foo x, Foo y)
    {
        return !MyEquality(x, y);
    }
    public override bool Equals(object y)
    {
      return MyEquality(this, y as Foo);
    }
    public override int GetHashcode()
    {
      // Implement GetHashcode to follow the Prime Directive Of GetHashcode:
      // Thou shalt implement GetHashcode such that if x.Equals(y) is true then 
      // x.GetHashcode() == y.GetHashcode() is always also true.
    }
    public bool Equals(Foo y)
    {
      return MyEquality(this, y);
    }
