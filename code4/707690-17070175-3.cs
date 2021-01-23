    public class SomeController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = TempData["ModelState"];
            if (modelState != null && !ModelState.Equals(modelState))
            {
                ModelState.Merge((ModelStateDictionary)modelState);
            }
            
            base.OnActionExecuted(filterContext);
        }
        
        private void SetModelState(ModelStateDictionary modelState)
        {
            TempData["ModelState"] = modelState;
        }
        
        private void SetViewModel(SqlAdminViewModel viewModel)
        {
            TempData["ViewModel"] = viewModel;
        }
        
        private SomeViewModel GetViewModel()
        {
            var viewModelTempData = TempData["ViewModel"];
            
            var viewModel = viewModelTempData != null
                                ? (SomeViewModel) TempData["ViewModel"]
                                : BuildSomeViewModel();
            
            return viewModel;
        }
        
        public ActionResult Index()
        {
            var viewModel = GetViewModel();
            
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Method(SomeMethodViewModel model)
        {
            if(HasError(model))
            {
                var viewModel = GetViewModel();
                viewModel.SomeMethod = model;
                
                SetViewModel(viewModel);
                
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        
        privare bool HasError(SomeMethodViewModel model)
        {
            var hasError = false;
            
            // Model validation logic
            
            if(hasError)
            {
                SetModelState(ModelState);
            }
            
            return hasError;
        }
    }
