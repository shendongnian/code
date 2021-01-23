    public class ThingModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
									ModelBindingContext bindingContext)
          {
            var model = (Thing)base.BindModel(controllerContext, bindingContext);
            var baseController = controllerContext.Controller as BaseController;
            if (baseController != null)
            {
                model.CurrentUser = baseController.CurrentUser;
                model.PersonalSettings = baseController.PersonalSettings;
            }
            return model;
          }
    }
