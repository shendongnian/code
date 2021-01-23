public override async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            MyService = context.HttpContext.
                               RequestServices.GetService(typeof(IMyService)) as IMyService;
        }
