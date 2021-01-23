    public class SchoolTypeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            SchoolType output = null;
            int id;
            ValueProviderResult parameter = bindingContext.ValueProvider.GetValue("id");
            if (parameter != null)
            {
                id = (int)parameter.ConvertTo(typeof(int));
                output = container.SchoolTypeSet.FirstOrDefault(t => t.Id == id);
            }
            return output;
        }
    }
