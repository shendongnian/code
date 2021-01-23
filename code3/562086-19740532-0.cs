	public class MyModelMetadataProvider : DataAnnotationsModelMetadataProvider
	{
		protected override ModelMetadata CreateMetadata(
			IEnumerable<Attribute> attributes,
			Type containerType,
			Func<object> modelAccessor,
			Type modelType,
			string propertyName)
		{
			//If containerType is an interface, get the actual type and the attributes of the current property on that type.
			if (containerType != null && containerType.IsInterface)
			{
				object target = modelAccessor.Target;
				object container = target.GetType().GetField("container").GetValue(target);
				containerType = container.GetType();
				var propertyDescriptor = this.GetTypeDescriptor(containerType).GetProperties()[propertyName];
				attributes = this.FilterAttributes(containerType, propertyDescriptor, Enumerable.Cast<Attribute>((IEnumerable)propertyDescriptor.Attributes));
			}
			var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            //This single line is for the "sidenote" in my text above, remove if you don't use this:
			attributes.OfType<MetadataAttribute>().ToList().ForEach(x => x.Process(modelMetadata));
			return modelMetadata;
		}
	}
