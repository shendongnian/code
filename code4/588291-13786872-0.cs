             var controllerName = (string)filterContext.RouteData.Values["controller"]; 
             var actionName = (string)filterContext.RouteData.Values["action"]; 
             var model = new HandleErrorInfo(filterContext.Exception, controllerName,actionName); 
             filterContext.Result = new ViewResult 
             {             
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),  
                TempData = filterContext.Controller.TempData      
            };
