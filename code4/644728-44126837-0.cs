		private string[] myBoolPropertyNames = 
        {
			nameof(MyBool1Property),
			nameof(MyBool2Property)
		}; // MyBoolPropertyNames =
		private MyClass()
		{
			foreach (var propertyName in myBoolPropertyNames)
			{
				ReflectionHelper.SetPropertyValue
				(
					parentObject: this,
					propertyName: propertyName,
					untypedPropertyValue: true
				); // SetPropertyValue
			} // foreach (var propertyName in myBoolPropertyNames)
			foreach (var propertyName in myBoolPropertyNames)
			{
				bool boolPropertyValue = ReflectionHelper.GetPropertyValue<bool>
				(
					parentObject: this,
					propertyName: propertyName
				); // SetPropertyValue
				Console.WriteLine($"Property '{propertyName}' value: {boolPropertyValue}");
			} // foreach (var propertyName in myBoolPropertyNames)
		}
		public bool MyBool1Property { get; set; }
		public bool MyBool2Property { get; set; }
    
	} // MyClass
`
`
	public class ReflectionHelper
	{
		public static PropertyType GetPropertyValue<PropertyType>
		(
			object parentObject,
			string propertyName
		)
		{
			if (parentObject == null)
			{
				throw new ArgumentException
				(
					$"Missing '{nameof(parentObject)}'."
				);
			} // if (parentObject == null)
			PropertyInfo propertyInfo = parentObject.GetType().GetProperty(propertyName);
			if (propertyInfo == null)
			{
				throw new ArgumentException
				(
					"No PropertyInfo found for Property: " + propertyName
				);
			} // if (propertyInfo == null)
			object untypedPropertyValue = propertyInfo.GetValue(obj: parentObject);
			Type propertyType = 
			(
				Nullable.GetUnderlyingType(propertyInfo.PropertyType) 
				?? propertyInfo.PropertyType
			); // propertyType = 
			object typedPropertyValue = 
			(
				(untypedPropertyValue == null) 
				? null 
				: Convert.ChangeType(untypedPropertyValue, propertyType)
			); // typedPropertyValue = 
			return (PropertyType)typedPropertyValue;
		} // GetPropertyValue
		public static void SetPropertyValue
		(
			object parentObject,
			string propertyName,
			object untypedPropertyValue
		)
		{
			if (parentObject == null)
			{
				throw new ArgumentException
				(
					$"Missing '{nameof(parentObject)}'."
				);
			} // if (parentObject == null)
			PropertyInfo propertyInfo = parentObject.GetType().GetProperty(propertyName);
			if (propertyInfo == null)
			{
				throw new ArgumentException
				(
					"No PropertyInfo found for Property: " + propertyName
				);
			} // if (propertyInfo == null)
			Type propertyType = 
			(
				Nullable.GetUnderlyingType(propertyInfo.PropertyType) 
				?? propertyInfo.PropertyType
			); // propertyType = 
			object typedPropertyValue =
			(
				(untypedPropertyValue == null)
				? null
				: Convert.ChangeType(untypedPropertyValue, propertyType)
			); // typedPropertyValue = 
			propertyInfo.SetValue
			(
				obj: parentObject, 
				value: typedPropertyValue
			); // propertyInfo.SetValue
		} // SetPropertyValue
	} // ReflectionHelper
