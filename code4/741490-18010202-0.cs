    public class MyViewModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var query = controllerContext.HttpContext.Request.QueryString;
            var value = query["color"] ?? query["gul"] ?? query["couleur"];
            return new MyViewModel
            {
                Color = value,
            };
        }
    }
