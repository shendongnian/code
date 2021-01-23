    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public MyActionFilterAttribute()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //do something with Foo
            base.OnActionExecuting(filterContext);
        }
        [Inject]
        public IFoo Foo { get; set; }
    }
