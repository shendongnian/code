	void Main()
	{
		var conversion = new ConversionService();
		var wantedType = typeof(string);
		Task<object> originalTask = Task<object>.Factory.StartNew(
           () => { /* test impl */ return 1; }); 
		var nextTask = originalTask.ContinueWith(prev =>
           conversion.ConvertObject(prev.Result.GetType(), wantedType, prev.Result));
		
		var result = nextTask.Result;
		Console.WriteLine("{0} - {1}", result.GetType(), result);
	}
	
	class ConversionService
	{
		public object ConvertObject(Type source, Type dest, object input)
		{
			// test impl.
			return Convert.ChangeType(input, dest);
		}
	}
