	public class InterfaceModelBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelType.IsInterface)
			{
				Type desiredType = Type.GetType(
					EncryptionService.Decrypt(
						(string)bindingContext.ValueProvider.GetValue("AssemblyQualifiedName").ConvertTo(typeof(string))));
				bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, desiredType);
			}
			return base.BindModel(controllerContext, bindingContext);
		}
	}
