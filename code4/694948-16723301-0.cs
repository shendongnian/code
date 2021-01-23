    class Holder<T> where T:struct
    {
      public T This;
      public override String ToString() { return This.ToString(); }
      public override bool Equals(object other) { return This.Equals(other); }
      etc.
    }
