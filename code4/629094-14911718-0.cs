    var parent = new ParentObject{ SomeProperty1 = "    test" };
	var pe = Expression.Constant(parent);
    var property = Expression.Property(pe, typeof(ParentObject).GetProperty("SomeProperty1"));
    var call = Expression.Call(property, typeof(string).GetMethod("Trim", Type.EmptyTypes));
	
	var result = Expression.Lambda(call).Compile().DynamicInvoke();
	
	Console.WriteLine(result); // -> "test"
