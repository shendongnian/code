    public void OnResultExecuting(ResultExecutingContext filterContext) {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
                return;
            
            var layoutFile = viewResult.ViewBag.Layout; //the variable you set in your action executing,
            viewResult.MasterName = layoutFile;
            
        }
