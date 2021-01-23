    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var type = base.GetControllerType(requestContext, controllerName);
            if (type != null && IsIngored(type))
            {
                return null;
            }
            return type;
        }
        public static bool IsIngored(Type type)
        {
            return type.Assembly.GetCustomAttributes(typeof(IgnoreAssemblyAttribute), false).Any() 
                || type.GetCustomAttributes(typeof(IgnoreControllerAttribute), false).Any();
        }
    }
