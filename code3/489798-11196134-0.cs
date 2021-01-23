    public sealed class CommitOnSuccess : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                UnitOfWork.Commit();
        }
    }
