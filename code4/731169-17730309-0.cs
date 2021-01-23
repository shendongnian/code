    public class Bar
    {
      private Foo f; 
      public Bar(Foo value)
      {
        f = value;
      } 
    }
    
    Foo f = new Foo(); 
    Bar b = new Bar(f);
