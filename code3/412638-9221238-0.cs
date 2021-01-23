    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ServiceRouteAttribute : Attribute
    {
        public string RoutePrefix { get; set; }
        public Type ServiceFactoryType { get; set; }
        public ServiceHostFactoryBase ServiceFactory
        {
            get
            {
                if (ServiceFactoryType == null || !ServiceFactoryType.IsRelated(typeof(ServiceHostFactoryBase)))
                    return null;
                return Activator.CreateInstance(ServiceFactoryType) as ServiceHostFactoryBase;
            }
        }
        public ServiceRouteAttribute() : this(string.empty) { }
        public ServiceRouteAttribute(string routePrefix) : this(routePrefix, typeof(WebServiceHostFactory)) { }
        public ServiceRouteAttribute(string routePrefix, Type serviceFactoryType)
        {
            RoutePrefix = routePrefix;
            ServiceFactoryType = serviceFactoryType;
        }
    }
