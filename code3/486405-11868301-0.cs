    public static Object CreateGenericListOfType(Type typeGenericWillBe)
		{
			//alternative to the followin:
			//List<Address> myList = new List<Address>(3);
			//build parameters for the generic's constructor (obviously this code wouldn't work if you had different constructors for each potential type)
			object[] constructorArgs = new Object[1];
			constructorArgs[0] = 3;
			//instantiate the generic.  Same as calling the one line example (commented out) above. Results in a List<String> with 3 list items
			Type genericListType = typeof(List<>);
			Type[] typeArgs = { typeGenericWillBe };
			Type myNewGeneric = genericListType.MakeGenericType(typeArgs);
			object GenericOfType = Activator.CreateInstance(myNewGeneric, constructorArgs);
			return GenericOfType;
		}
