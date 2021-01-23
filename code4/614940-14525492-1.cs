    public class SomeController
    {
      private readonly IMyAggregateService _aggregateService;
      public SomeController(
        IMyAggregateService aggregateService)
      {
        _aggregateService = aggregateService;
      }
    }
