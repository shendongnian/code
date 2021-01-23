    private readonly ConcurrentDictionary<Type, Func<ISomeObject>> someObjectCache =
      new ConcurrentDictionary<Type, Func<ISomeObject>>();
  
    public ISomeObject CreateSomeObject(Type someType) {
      return someObjectCache.GetOrAdd(someType, type => {
        if(!Attribute.IsDefined(someType, typeof(SomeAttribute))) {
          return () => TypicalFactoryFunctionality(someType);
        }
        var someObject = TypicalFactoryFunctionality(someType);
        return () => someObject;
      })();
    }
  
    private ISomeObject TypicalFactoryFunctionality(Type someType) {
      // ...
    }
