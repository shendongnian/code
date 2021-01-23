    class Foo
    {
        public int Bar { get; set; }
        public int Baz { get; set; }
        // ...
        public override int GetHashCode()
        {  return this.Bar.GetHashCode() ^ this.Baz.GetHashCode(); }
    }
