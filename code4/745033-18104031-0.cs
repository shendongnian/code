    private readonly ReadOnlyCollection<string> UnderlyingReadOnlyStrings;
    // populate the read-only collection, then...
   
    public ReadOnlyCollection<string> ReadOnlyStrings {
      get { return UnderlyingReadOnlyStrings; }
    }
