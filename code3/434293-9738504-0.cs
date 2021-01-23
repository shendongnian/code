    public class JsonNetResult : ActionResult
    {
        public JsonRequestBehavior JsonRequestBehavior { get; set; }
        ....
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var httpMethod = context.HttpContext.Request.HttpMethod;
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && 
                string.Equals(httpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("You can't access this action with GET");
            }
            ...
        }
    }
