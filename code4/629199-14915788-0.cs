    public class B : A
    {
      // This happens *before* the base-class constructor.
      public ExternalObject external = new ExternalObject();
      public B () : base() { }
    }
    public class C : A
    {
      public ExternalObject external;
      public C () : base()
      {
        // This happens *after* the base-class constructor.
        this.external = new ExternalObject();
      }
    }
