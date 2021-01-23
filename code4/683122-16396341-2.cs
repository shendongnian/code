    public static T2 Convert<T1, T2>(T1 obj)
    {
    	var conversionOperator = typeof(T1).GetMethods(BindingFlags.Static | BindingFlags.Public)
    	.Where(m => m.Name == "op_Explicit" || m.Name == "op_Implicit")
    	.Where(m => m.ReturnType == typeof(T2))
    	.Where(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(T1))
    	.FirstOrDefault();
    	
    	if (conversionOperator != null)
    		return (T2)conversionOperator.Invoke(null, new object[]{obj});
    	
    	throw new Exception("No conversion operator found");
    }
