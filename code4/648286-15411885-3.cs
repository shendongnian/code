	Assembly[] assembliesToInspect = {
										typeof(AnyClass).Assembly, 
										typeof(ClassFromAnotherAssembly).Assembly
									 };
									 
	var allMethods = assembliesToInspect.SelectMany(assembly => assembly.GetTypes())
                                        .SelectMany(type => type.GetMethods());		
