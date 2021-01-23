    public class BaseController:Controller
    {
        protected override void ExecuteCore()
        {
          var somevar = HttpContext.Request.QueryString["SomveVariable"];
