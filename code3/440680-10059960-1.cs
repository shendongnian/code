    private readonly ConcurrentDictionary<Type, Func<ISomeObject>> someObjectCache =
      new ConcurrentDictionary<Type, Func<ISomeObject>>();
    public ISomeObject CreateSomeObject(Type someType) {
      return someObjectCache.GetOrAdd(someType, _ => {
        if(!ShouldCache(someType)) {
          return () => Create(someType);
        }
        var someObject = Create(someType);
        return () => someObject;
      })();
    }
    private bool ShouldCache(Type someType) {
      return Attribute.IsDefined(someType, typeof(SomeAttribute));
    }
    private ISomeObject Create(Type someType) {
      // typical factory functionality ...
    }
