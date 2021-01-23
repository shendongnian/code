[MyAuth(Roles = "admin")]
public class ValuesController : ApiController
{
    [ExemptRoles]
    public IEnumerable&lt;string> Get()
    {
        return new string[] { "value1", "value2" };
    }
}
public class ExemptRolesAttribute : Attribute { }
public class MyAuthAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        if (actionContext.ActionDescriptor
                .GetCustomAttributes&lt;ExemptRolesAttribute>().Any())
            base.Roles = String.Empty;
        base.OnAuthorization(actionContext);
    }
}
