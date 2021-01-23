	TestClass test = new TestClass();
	Type type1 = test.value.GetType(); // Gets the type of the data inside the field ==> System.Int32.
	Type underlyingType1 = Nullable.GetUnderlyingType(type1); // Gets the underlying type of System.Int32 ==> null.
	FieldInfo field = typeof(TestClass).GetFields(BindingFlags.Instance | BindingFlags.Public)[0];
	Type type2 = field.FieldType; // Now the type is retrieved of the field, not the data inside. ==> System.Int32?
	Type underlyingType2 = Nullable.GetUnderlyingType(type2); // Gets the underlying type of System.Int32? ==> System.Int32.
