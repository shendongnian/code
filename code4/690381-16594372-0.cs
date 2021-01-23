    var baseType = typeof(BaseClass);
    var types = Assembly
    	.GetExecutingAssembly()
    	.GetTypes()
    	.Where(z => baseType.IsAssignableFrom(t) && t.GetCustomAttributes(typeof(PostTransformerAttribute), true).Any());
