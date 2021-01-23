    public class Foo
    {
        public string Bar { get; set; }
    }
    public void SomeStrangeMethod()
    {
        Foo foo = new Foo() { Bar = "Hello" };
        string result = GetName(()=>foo.Bar);  // should return "Bar"
		Debug.WriteLine(result); // "Bar"
    }
	
    public static string GetName<T>(Expression<Func<T>> expression)
	{
	    return ExtractPropertyName(expression);
	}
	/// <summary>
	/// Extracts the name of a property from a suitable LambdaExpression.
	/// </summary>
	/// <param name="propertyExpression">The property expression.</param>
	/// <returns></returns>
	public static string ExtractPropertyName(LambdaExpression propertyExpression)
	{
		if (propertyExpression == null)
		{
			throw new ArgumentNullException("propertyExpression");
		}
		var memberExpression = propertyExpression.Body as MemberExpression;
		if (memberExpression == null)
		{
			throw new ArgumentException(@"Not a member expression", "propertyExpression");
		}
		var property = memberExpression.Member as PropertyInfo;
		if (property == null)
		{
			throw new ArgumentException(@"Not a property", "propertyExpression");
		}
		var getMethod = property.GetGetMethod(true);
		if (getMethod.IsStatic)
		{
			throw new ArgumentException(@"Can't be static", "propertyExpression");
		}
		return memberExpression.Member.Name;
	}
