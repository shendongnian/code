    namespace System.Web.Mvc
    {
        public abstract class Controller : ControllerBase, (etc)
        {
            ...
            protected internal virtual PartialViewResult PartialView(
                string viewName, object model)
            {
                if (model != null)
                    this.ViewData.Model = model;
                PartialViewResult partialViewResult = new PartialViewResult();
                partialViewResult.ViewName = viewName;
                partialViewResult.ViewData = this.ViewData;
                partialViewResult.TempData = this.TempData;
                partialViewResult.ViewEngineCollection = this.ViewEngineCollection;
                return partialViewResult;
            }
            ...
        }
    }
