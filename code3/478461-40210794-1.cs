		// Checks if object typed json or xml has a specific property
		public static bool IsPropertyExistsOpenStandardFormat(dynamic dynamicObject, string propertyName)
		{
			try
			{
				var x = dynamicObject[propertyName];
				if (x != null)
					return true;
			}
			catch 
			{
				return false;
			}
			
		}
		// Checks if standard object has a specific property
		public static bool IsPropertyExistsStandard(dynamic dynamicObject, string propertyName)
		{
			return dynamicObject.GetType().GetProperty(propertyName) != null;
		}
