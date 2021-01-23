    public class ChildController : Controller, IChildController<TViewModel, TModel>
    {
        private IChildControllerFactory _childControllerFactory;
    
        public ChildController() 
        {
        }
    
        public void setChildControllerFactory( IChildControllerFactory childControllerFactory )
        {
           _childControllerFactory = childControllerFactory;
        }
    
        public ActionResult GetChildViewModel(object child)
        {
            var model = _childControllerFactory.GetChildController(child).ToViewModel(survey);
            return PartialView("Child.ascx", model);
        }
    }
