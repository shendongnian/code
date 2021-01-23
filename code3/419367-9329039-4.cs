    public class TransactionalAttribute : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // let the container dispose/rollback the UoW.
            if (filterContext.Exception == null)
                _unitOfWork.SaveChanges();
            base.OnActionExecuted(filterContext);
        }
    }
