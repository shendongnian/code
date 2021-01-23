class Foo
{
    public int Data
    {
        get;
        set;
    }
}
class Program
{
    static Action&lt;object, object&gt; MakeSetter(PropertyInfo info)
    {
        var objectParameter = Expression.Parameter(typeof(object), string.Empty);
        var valueParameter = Expression.Parameter(typeof(object), string.Empty);
        var setterExpression = Expression.Lambda&lt;Action&lt;object, object&gt;&gt;(
            <strong>ExpressionEx.Assign</strong>(
                Expression.Property(
                    Expression.Convert(objectParameter, info.DeclaringType),
                    info),
                Expression.Convert(valueParameter, info.PropertyType)),
            objectParameter,
            valueParameter);
        return setterExpression.Compile();
    }
    static void Main()
    {
        var foo = new Foo();
        var property = typeof(Foo).GetProperty("Data");
        var setter = MakeSetter(property);
        setter(foo, 10);
        Console.WriteLine(foo.Data);
    }
}
