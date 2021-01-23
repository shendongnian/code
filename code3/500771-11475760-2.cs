	/// <summary>
	/// Model binder that will return null if all of the properties on a bound model come back as null
	/// It inherits from DefaultModelBinder because it uses the default model binding functionality.
	/// This implementation also needs to specifically have IModelBinder on it too, otherwise it wont get picked up as a Binder
	/// </summary>
	public class SearchDataModelBinder : DefaultModelBinder, IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			// use the default model binding functionality to build a model, we'll look at each property below
			object model = base.BindModel(controllerContext, bindingContext);
			// loop through every property for the model in the metadata
			foreach (ModelMetadata property in bindingContext.PropertyMetadata.Values)
			{
				// get the value of this property on the model
				var value = bindingContext.ModelType.GetProperty(property.PropertyName).GetValue(model, null);
				// if any property is not null, then we will want the model that the default model binder created
				if (value != null)
					return model;
			}
			// if we're here then there were either no properties or the properties were all null
			return null;
		}
	}
