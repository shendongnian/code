    public class Facility : AbstractFacility
    {
        protected override void Init() { Kernel.ComponentRegistered += KernelComponentRegistered; }
    
        static readonly List<Type> TypesNotToIntercept = new List<Type>
        {
            typeof(IInterceptor),   //Don't intercept Interceptors
            typeof(MulticastDelegate),  //Func<> and the like
            typeof(LateBoundComponent), //Resolved with a factory, such as MongoDatabase
        };
        static void KernelComponentRegistered(string key, IHandler handler)
        {
            if (TypesNotToIntercept.Any(type => type.IsAssignableFrom(implementation));
                return;
            handler.ComponentModel.Interceptors.AddIfNotInCollection(InterceptorReference.ForKey("SomeInterceptor"));
        }
    }
