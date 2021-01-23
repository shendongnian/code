    // the dictionary now stores functions
    private readonly ConcurrentDictionary<Type, Func<ISomeObject>> someObjectCache =
      new ConcurrentDictionary<Type, Func<ISomeObject>>();
    public ISomeObject CreateSomeObject(Type someType) {
      return someObjectCache.GetOrAdd(someType, _ => {
        if(ShouldCache(someType)) {
          // caching should be used
          // return a function that returns a cached instance
          var someObject = Create(someType);
          return () => someObject; 
        }
        else {
          // no caching should be used
          // return a function that always creates a new instance
          return () => Create(someType); 
        }
      })(); // call the returned function
    }
    private bool ShouldCache(Type someType) {
      return Attribute.IsDefined(someType, typeof(SomeAttribute));
    }
    private ISomeObject Create(Type someType) {
      // typical factory functionality ...
    }
