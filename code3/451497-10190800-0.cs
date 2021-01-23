    public class Foobar
    {
    }
    
    public class ViewState
    {
      private readonly Lazy<Foobar> _foobar = new Lazy<Foobar>();
    
      public Foobar LazyFoobar
      {
        get { return _foobar.Value; }
      }
    }
    
    // Gets or creates the foobar
    Foobar lazyFoobar = this.ViewState.LazyFoobar;
