	var theMethodISeek = typeof(MyClass).GetMethods()
		.Where(m => m.Name == "Add" && m.IsGenericMethodDefinition)
		.Where(m =>
				{
					// the generic T type
					var typeT = m.GetGenericArguments()[0];
					// SomeType<T>
					var someTypeOfT = 
						typeof(SomeType<>).MakeGenericType(new[] { typeT });
							
					return m.GetParameters().First().ParameterType == someTypeOfT;
				})
		.First();
