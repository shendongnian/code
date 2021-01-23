    struct S {
      private readonly string value;
      public string Value { get { return value; } }
      public S(string value) { this.value = value; }
      public override string ToString() { return value ?? ""; }
      public override int GetHashCode() {return value==null?0:value.GetHashCode();}
      public override bool Equals(object obj) { return value == ((S) obj).value; }
    }
