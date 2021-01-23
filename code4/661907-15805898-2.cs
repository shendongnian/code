    public void HandleBusinessException(BusinessExceptionDto exceptionDto)
    {
         var controller= HttpContext.Current.Session["controllerInstance"] as BaseController;
         if(controller != null) 
         {
             controller.SetNotification(); 
         }
    }
