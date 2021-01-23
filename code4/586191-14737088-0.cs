    ControllerBase controllerToLinkTo = string.IsNullOrEmpty(controllerName)
                                                            ? htmlHelper.ViewContext.Controller
                                                            : GetControllerByName(htmlHelper, controllerName);
        
    var controllerContext = new ControllerContext(htmlHelper.ViewContext.RequestContext, controllerToLinkTo);
    var controllerDescriptor = new ReflectedControllerDescriptor(controllerToLinkTo.GetType());
    var actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
    //add the following lines
    if (actionDescriptor == null)
    {
        actionDescriptor = controllerDescriptor.GetCanonicalActions().FirstOrDefault(a => a.ActionName == actionName);
    }
