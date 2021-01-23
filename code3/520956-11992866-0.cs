    public class CustomControllerFactory : DefaultControllerFactory
    {
        public Dictionary<string, string> DomainNamespaces { get; set; }
        public CustomControllerFactory(Dictionary<string, string> domainNamespaces)
            : base()
        {
            DomainNamespaces = domainNamespaces;
        }
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            controllerName += controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) ? String.Empty : "Controller";
            string requestDomain = requestContext.HttpContext.Request.Url.Host;
            string defaultNamespace = "API.Controllers.Base";
            string deploymentNamespace = "API.Controllers.Deployments." + DomainNamespaces[requestDomain];
            Assembly asm = Assembly.GetExecutingAssembly();
            Type deploymentMatch = null;
            Type defaultMatch = null;
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == deploymentNamespace && type.Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                {
                    deploymentMatch = type;
                }
                else if (type.Namespace == defaultNamespace && type.Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                {
                    defaultMatch = type;
                }
            }
            return deploymentMatch ?? defaultMatch;
        }
    }
