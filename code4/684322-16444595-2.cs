    [MyAuth(Roles = "admin")]
    public class ValuesController : ApiController
    {
        [ExemptRoles]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
    
    public class ExemptRolesAttribute : Attribute { }
    
    public class MyAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.HasMarkerAttribute<ExemptRolesAttribute>()
                || actionContext.Controller.HasMarkerAttribute<ExemptRolesAttribute>())
                base.Roles = String.Empty;
    
            base.OnAuthorization(actionContext);
        }
    }
    
    static class MarkerAttributeExtensions
    {
        public static bool HasMarkerAttribute<T>(this Controller that)
        {
            return that.GetType().GetCustomAttributes<T>().Any();
        }
    
        public static bool HasMarkerAttribute<T>(this ActionDescriptor that)
        {
            return that.GetCustomAttributes<T>().Any();
        }
    
        public static IEnumerable<T> GetCustomAttributes<T>(this Type that)
        {
            return that.GetCustomAttributes(typeof(T), false).Cast<T>();
        }
    
        public static IEnumerable<T> GetCustomAttributes<T>(this ActionDescriptor that)
        {
            return that.GetCustomAttributes(typeof(T), false).Cast<T>();
        }
    }
