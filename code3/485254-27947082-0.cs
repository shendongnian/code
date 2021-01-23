    public static class ObjectCloner {
		public static T Clone<T>(object obj, bool deep = false) where T : new() {
			if (!(obj is T)) {
				throw new Exception("Cloning object must match output type");
			}
			return (T)Clone(obj, deep);
		}
		public static object Clone(object obj, bool deep) {
			if (obj == null) {
				return null;
			}
			Type objType = obj.GetType();
			if (objType.IsPrimitive || objType == typeof(string) || objType.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0) == null) {
				return obj;
			}
			List<PropertyInfo> properties = objType.GetProperties().ToList();
			if (deep) {
				properties.AddRange(objType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic));
			}
			object newObj = Activator.CreateInstance(objType);
			foreach (var prop in properties) {
				if (prop.GetSetMethod() != null) {
					var proceed = true;
					if (obj is IList) {
						var listType = obj.GetType().GetProperty("Item").PropertyType;
						if (prop.PropertyType == listType) {
							proceed = false;
							foreach (var item in obj as IList) {
								object clone = Clone(item, deep);
								(newObj as IList).Add(clone);								
							}							
						}						
					}
					if (proceed) {
						object propValue = prop.GetValue(obj, null);
						object clone = Clone(propValue, deep);
						prop.SetValue(newObj, clone, null);
					}					
				}
			}
			return newObj;
		}
	}
