	FieldInfo field = typeof(Bla).GetField("sum", BindingFlags.NonPublic |
                                                  BindingFlags.Instance);
	
	var bla = new Bla();
	field.SetValue(bla, 42);
	
	Console.WriteLine (field.GetValue(bla)); //prints 42
