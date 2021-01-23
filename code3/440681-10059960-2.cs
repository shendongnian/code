    // the dictionary now stores functions
    private readonly ConcurrentDictionary<Type, Func<ISomeObject>> someObjectCache =
      new ConcurrentDictionary<Type, Func<ISomeObject>>();
    public ISomeObject CreateSomeObject(Type someType) {
      return someObjectCache.GetOrAdd(someType, _ => {
        if(!ShouldCache(someType)) {
          return () => Create(someType); // always create a new instance
        }
        var someObject = Create(someType);
        return () => someObject; // return a cached instance
      })(); // "execute" the value stored in the dictionary
    }
    private bool ShouldCache(Type someType) {
      return Attribute.IsDefined(someType, typeof(SomeAttribute));
    }
    private ISomeObject Create(Type someType) {
      // typical factory functionality ...
    }
