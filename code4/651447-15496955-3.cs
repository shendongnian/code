    public class CoordinateModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int[][] result;
            // similar parsing code as above
            return result;
        }
    }
    public ActionResult GetByCoordinatesRoute([ModelBinder(typeof(ContactBinder))]int[][] coords)
    {
        ...
    }
