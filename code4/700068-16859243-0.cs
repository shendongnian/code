    public class CreateModelBinder : DefaultModelBinder
    {
         public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
         {
              //assign request parameters here, and return a CreateViewModel
              //for example
              CreateViewModel cVM = new CreateViewModel();
              cVM.Name = controllerContext.HttpContext.Request.Params["Name"];
              return cVM;
         }
    }
