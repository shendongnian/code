    var myNewTruck = ServiceInvoker.Invoke<TruckService>(x => x.CreateTruck(dto));
    public class ServiceInvoker
    {
        public ReturnType Invoke<ServiceType, ReturnType>(Expression<Func<ServiceType, ReturnType>> methodExpression)
        {
            // blah blah
            var myService = IoC.Resolve<ServiceType>();
            return methodExpression.Compile()(myService); // etc
        }
    }
