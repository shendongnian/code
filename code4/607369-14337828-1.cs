    internal class ThingInitalizationService
    {
      private readonly IThingInitializationStrategy _initStrategy;
    
      public ThingInitalizationService(IThingInitializationStrategy initStrategy)
      {
         _initStrategy = initStrategy;
      }
    
      public Initialize(Thing thing)
      {
        _initStrategy.Initialize(thing);
      }
    }
