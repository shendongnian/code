		foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
		{
			// class attributes
			foreach (var typeAttr in type.GetCustomAttributes(typeof(DisplayAttribute), false))
			{
				Console.WriteLine(((DisplayAttribute)typeAttr).Name);
				Console.WriteLine(((DisplayAttribute)typeAttr).Description);
			}
			// members attributes
			foreach (var props in type.GetProperties())
			{
				foreach (var propsAttr in props.GetCustomAttributes(typeof(DisplayAttribute), false))
				{
					Console.WriteLine(((DisplayAttribute)propsAttr).Name);
					Console.WriteLine(((DisplayAttribute)propsAttr).Description);
				}
			}
		}
