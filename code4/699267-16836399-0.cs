	var a = new A{B = "V1", C = "V2", D = "V3"};
	var dictionary = a.GetType()
					  .GetProperties()
					  .ToDictionary(prop => prop.Name, 
					 				prop => prop.GetValue(a));
							
