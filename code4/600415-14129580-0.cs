    public void WhatsaFoo(object obj)
    {
    	var genericType = obj.GetType().GetGenericTypeDefinition();
    	if(genericType == typeof(Foo<>))
    	{
            // Figure out what generic args were used to make this thing
            var genArgs = obj.GetType().GetGenericArguments();
            // fetch the actual typed variant of Foo
            var typedVariant = genericType.MakeGenericType(genArgs);
            // alternatively, we can say what the type of T is...
            var typeofT = obj.GetType().GetGenericArguments().First();
            // or fetch the list...
            var itemsOf = typedVariant.GetProperty("Items").GetValue(obj, null);
    	}
    }
