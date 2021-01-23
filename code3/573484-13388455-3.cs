    interface IRule<T>
    {
         bool IsBroken(T model);
         ErrorMessage Message {get;}
    }
    interface IRulesEngine
    {
         IEnumerable<ErrorMessage> Validate<T>(T model);
    }
    class ErrorMessage
    {
          public string Property {get;set;}
          public string Message {get;set;}
    }
    class RulesEngine : IRulesEngine
    {
         private readonly IContainer container;
         public RulesEngine(IContainer container)
         {
              this.container = container;
         }
         public IEnumerable<ErrorMessage> Validate<T>(T model)
         {
               return container
                         .GetInstances<IRule<T>>()
                         .Where(rule => rule.IsBroken(model))
                         .Select(rule =>  rule.Message);
         }
    }
