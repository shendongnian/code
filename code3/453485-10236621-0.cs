    public class ClassBase<TService>
    {
         protected Func<TService> _serviceFactory = null;
         public ClassBase(Func<TService> serviceFactory)
         {
             _serviceFactory = serviceFactory;
         }
         public virtual TResponse Invoke<TResponse>(Func<TService, TResponse> valueFactory)
         {
              // Do Stuff
              TService service = serviceFactory();
              return valueFactory(service);
         }
    }
