        public class NullModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                 // use the default model binding functionality to build a model, we'll look at each property below
                 object model = base.BindModel(controllerContext, bindingContext);
                 // loop through every property for the model in the metadata
                 foreach (ModelMetadata property in bindingContext.PropertyMetadata.Values)
                 {
                     // get the value of this property on the model
                     var value = bindingContext.ModelType.GetProperty(property.PropertyName).GetValue(model, null);
                     // if any property is not null, then we will want the model that the default model binder created
                     if (value != null) return model;
                 }
                 // if we're here then there were either no properties or the properties were all null
                 return null;
            }
      }
