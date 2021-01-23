cs
   if (obj is System.RuntimeType)
prompts the error:
> inaccessible due to its protection level.
So the solution from @dtb above is the right one.  Expanding on their answer:
cs
void Main()
{
		object obj = "";
	// obj = new {}; // also works
	// This works
	IsRuntimeType(obj.GetType()); // Rightly prints "it's a System.Type"
	IsRuntimeType(obj.GetType().GetType()); // Rightly prints "it's a System.RuntimeType"
	// This proves that @Hopeless comment to the accepted answer from @dtb does not work
	IsWhatSystemType(obj.GetType()); // Should return "is a Type", but doesn't
	IsWhatSystemType(obj.GetType().GetType());
}
// This works
void IsRuntimeType(object obj)
{
	if (obj == typeof(Type).GetType())
		// Can't do `if (obj is System.RuntimeType)` -- inaccessible due to its protection level
		Console.WriteLine("object is a System.RuntimeType");
	else if (obj is Type)
		Console.WriteLine("object is a System.Type");
}
// This proves that @Hopeless solution in his comment to the accepted answer from @dtb does not work
void IsWhatSystemType(object obj)
{
	if (obj is TypeInfo)
		Console.WriteLine("object is a System.RuntimeType");
	else
		Console.WriteLine("object is a Type");
}
Working .NET fiddle [here](https://dotnetfiddle.net/0WIUdQ).
