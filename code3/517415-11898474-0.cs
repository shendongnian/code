    public static bool operator ==(SomeType a, SomeType b)
    {
        return a.Equals(b);
    }
    public virtual bool Equals(SomeType b)
    {
       // yours logic here
       return base.Equals(b)
    }
