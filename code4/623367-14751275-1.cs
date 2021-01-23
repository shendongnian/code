    public static void SetStringPropertiesEmpty(TestClass testClass)
	{
    	// # Get all properties of testClass instance
		PropertyDescriptorCollection propDescCollection = TypeDescriptor.GetProperties(testClass);
		// # Iterate over the property collection
		foreach (PropertyDescriptor property in propDescCollection)
		{
			string name = property.Name;
			Type t = property.PropertyType; // # Get property type
			object value = property.GetValue(testClass); // # Get value of the property (value that member variable holds)
			if (t == typeof(string)) // # If type of propery is string and value is null
			{
				property.SetValue(testClass, String.Empty); // # Set value of the property (set member variable)
				value = String.Empty; // # <-- To prevent NullReferenceException when printing out
			}
				Console.WriteLine("*****\nName:\t{0}\nType:\t{1}\nValue:\t{2}", name, t.ToString(), value.ToString());
			}
			Console.WriteLine("*****");
			Console.Read();
		}
    }
