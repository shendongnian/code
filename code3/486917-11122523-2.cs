	public class MyClass
	{
		public IEnumerable<string> _parameters = new[] { "Val1", "Val2", "Val3" };
			
		public void PrintField()
		{
			var parameters = this.GetType().GetField("_parameters").GetValue(this) as IEnumerable;
			
			// Prints:
			// Val1
			// Val2
		    // Val3
			foreach(var item in parameters)
			{
				Console.WriteLine(item);
			}
		}
	}
