    const string TYPE = "System.String";
    Type type = Type.GetType(TYPE);
    if (type == null)
    {
    	// Type doesn't exist--at least, not in mscorlib or current assembly,
    	// or we didn't specify the assembly.
    	throw new Exception("Could not find type " + TYPE + ".");
    }
    
    // Note the Type array.  These are the types of the parameters that the
    // constructor takes.
    ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(char), typeof(int) });
    if (ctor == null)
    {
    	// Constructor doesn't exist that takes those parameters.
    	throw new Exception("Could not find proper constructor in " + TYPE + ".");
    }
    
    // Note the object array.  These are the actual parameters passed to the
    // constructor.  They should obviously match the types specified above.
    string result = (string)ctor.Invoke(new object[] { 'a', 5 });
